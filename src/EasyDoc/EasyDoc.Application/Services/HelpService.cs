using EasyDoc.Application.Interfaces;
using System;

namespace EasyDoc.Application.Services
{
    public class HelpService : IHelpService
    {
        public void GetHelp()
        {
            Console.Write("usage: easydoc [--version] [--help]");
            Console.WriteLine("");
            Console.WriteLine("These are common easydoc commands:");
            Console.WriteLine("");
        }
    }
}
