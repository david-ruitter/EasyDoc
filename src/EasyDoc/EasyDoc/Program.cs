using EasyDoc.Application.Interfaces;
using EasyDoc.Domain.Core.Bus;
using EasyDoc.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MediatR;
using System.Collections.Generic;

namespace EasyDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddApplicationServices()
                .AddCommandHandlers()
                .AddRequestHandlers()
                .AddMediatR(typeof(Program))
                .AddScoped<IMediatorHandler, MediatorHandler>()
                .BuildServiceProvider();

            //args = new string[] { "-h"};

            var _commandService = serviceProvider.GetService<ICommandService>();
            var result = _commandService.ConvertInputToCommandsAndParams(args);

            if (result != null)
            {
                foreach (var r in result)
                {
                    // Command Behaviour
                    if (r.Key == "--help" || r.Key == "-h")
                    {
                        var _helpService = serviceProvider.GetService<IHelpService>();
                        _helpService.GetHelp();
                    }
                    if (r.Key == "--version" || r.Key == "-v")
                    {
                        Console.WriteLine("easydoc version: 1.0.0");
                    }
                    if (r.Key == "--output" || r.Key == "-o")
                    {
                        var _fileService = serviceProvider.GetService<IFileOutputService>();
                        _fileService.WriteFile();
                    }
                    // Basic behaviour
                    var _fileInputService = serviceProvider.GetService<IFileInputService>();
                    var folders = _fileInputService.GetFilePaths(new List<string>() { @"C:\Development\AusbildungsnachweiseAutomation" });
                    var inputFiles = _fileInputService.ReadFiles(folders);
                }
            }
        }
    }
}
