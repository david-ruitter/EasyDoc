using EasyDoc.Application.Interfaces;
using EasyDoc.Domain.Core.Bus;
using EasyDoc.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MediatR;

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

            if (args.Contains("--help") || args.Contains("-h"))
            {
                var _helpService = serviceProvider.GetService<IHelpService>();
                _helpService.GetHelp();
            }
            if (args.Contains("--output") || args.Contains("-o"))
            {
                var _fileService = serviceProvider.GetService<IFileService>();
                _fileService.WriteFile();
            }
        }
    }
}
