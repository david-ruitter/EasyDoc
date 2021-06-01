using EasyDoc.Application.Interfaces;
using EasyDoc.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace EasyDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddApplicationServices()
                .BuildServiceProvider();

            if (args.Contains("--help"))
            {
                var _helpService = serviceProvider.GetService<IHelpService>();
                _helpService.GetHelp();
            }
        }
    }
}
