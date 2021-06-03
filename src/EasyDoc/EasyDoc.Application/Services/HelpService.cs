using EasyDoc.Application.Interfaces;
using System;

namespace EasyDoc.Application.Services
{
    public class HelpService : IHelpService
    {
        public void GetHelp()
        {
            Console.WriteLine(  
                "usage: easydoc \t[--version | -v] [--help | -h]\n" +
                "\t \t[--input | -i] <absolute input path>\n" +
                "\t \t[--output | -o] <absolute output path>\n" +
                "These are common easydoc commands:\n\n" +
                "get information about easydoc\n" +
                "  --version | -v \t Returns the version of easydoc you are using\n" +
                "  --help    | -h \t Shows which commands are available\n\n" +
                "choose paths\n" +
                "  --input   | -i \t Selects the path which is used to read the files you want to document\n" +
                "  --ouput   | -o \t Selects the path were your file/files are out putted"        
            );
        }
    }
}
