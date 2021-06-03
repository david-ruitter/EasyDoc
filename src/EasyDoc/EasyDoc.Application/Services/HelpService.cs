using EasyDoc.Application.Interfaces;
using System;

namespace EasyDoc.Application.Services
{
    public class HelpService : IHelpService
    {
        public void GetHelp()
        {
            Console.WriteLine("usage: easydoc \t[--version | -v] [--help | -h]");
            Console.WriteLine("\t \t[--input | -i] <absolute input path>");
            Console.WriteLine("\t \t[--output | -o] <absolute output path>");
            
            Console.WriteLine("These are common easydoc commands:");
            Console.WriteLine("");
            Console.WriteLine("get information about easydoc");
            Console.WriteLine("  --version | -v \t Returns the version of easydoc you are using");
            Console.WriteLine("  --help    | -h \t Shows which commands are available");
            Console.WriteLine("");
            Console.WriteLine("choose paths");
            Console.WriteLine("  --input   | -i \t Selects the path which is used to read the files you want to document");
            Console.WriteLine("  --ouput   | -o \t Selects the path were your file/files are out putted");
            Console.WriteLine("");
        }
    }
}
