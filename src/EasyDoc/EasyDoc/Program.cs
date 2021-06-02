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

            //args = new string[] { "-h"};

            var _commandService = serviceProvider.GetService<ICommandService>();
            var result = _commandService.ConvertInputToCommandsAndParams(args);

            if (result != null)
            {
                foreach (var r in result)
                {
                    if (r.Key == "--help" || r.Key == "-h")
                    {
                        var _helpService = serviceProvider.GetService<IHelpService>();
                        _helpService.GetHelp();
                    }
                    if (r.Key == "--output" || r.Key == "-o")
                    {
                        var _fileService = serviceProvider.GetService<IFileService>();
                        _fileService.WriteFile();
                    }
                }
            }
        }
    }
}
