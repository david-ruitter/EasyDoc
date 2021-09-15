using EasyDoc.Application.Interfaces;
using EasyDoc.Domain.Core.Bus;
using EasyDoc.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using MediatR;
using System.Collections.Generic;
using EasyDoc.Application.Models;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace EasyDoc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddApplicationServices()
                .AddCommandHandlers()
                .AddRequestHandlers()
                .AddMediatR(typeof(Program))
                .AddScoped<IMediatorHandler, MediatorHandler>()
                .BuildServiceProvider();

            // args = new string[] { };

            var _commandService = serviceProvider.GetService<ICommandService>();

            Dictionary<string, List<string>>? result;
            if (args == null || !args.Any())
            {
                result = _commandService.ConvertInteractive();
            }
            else
            {
                result = _commandService.ConvertInputToCommandsAndParams(args);
            }

            if (result == null)
            {
                return;
            }

            var defaultFormat = "json";
            var outputPath = Directory.GetCurrentDirectory();
            var _fileInputService = serviceProvider.GetService<IFileInputService>();
            var folders = new List<string[]>();

            // Get Help
            if (result.ContainsKey("--help") || result.ContainsKey("-h"))
            {
                var _helpService = serviceProvider.GetService<IHelpService>();
                _helpService.GetHelp();
                return;
            }
            if (result.ContainsKey("--version") || result.ContainsKey("-v"))
            {
                Console.WriteLine("easydoc version: 1.0.0");
                return;
            }
            foreach (var r in result)
            {
                // Command Behaviour
                if (r.Key == "--output" || r.Key == "-o")
                {
                    outputPath = r.Value[0];
                    continue;
                }
                if (r.Key == "--input" || r.Key == "-i")
                {
                    folders = _fileInputService.GetFilePaths(r.Value);
                }
                else
                {
                    folders = _fileInputService.GetFilePaths(null);
                }
            }
            var inputFiles = _fileInputService.ReadFiles(folders);

            var _documentationService = serviceProvider.GetService<IDocumentationService>();
            var documentations = new List<CommentOutput>();
            foreach (var inFile in inputFiles)
            {
                documentations.Add(await _documentationService.CreateDocumentationAsync(inFile));
            }

            // Format Files
            var _formatService = serviceProvider.GetService<IFormatService>();

            string formattedDocumentations = _formatService.FormatAs(documentations, defaultFormat);
            var _fileOutputService = serviceProvider.GetService<IFileOutputService>();
            await _fileOutputService.WriteFile(formattedDocumentations, outputPath);
                
        }
    }
}
