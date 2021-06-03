using EasyDoc.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyDoc.Application.Services
{
    public class CommandService : ICommandService
    {
        public Dictionary<string, List<string>> ConvertInputToCommandsAndParams(string[] args)
        {
            var commandsAndParams = new Dictionary<string, List<string>>();

            string currentCommand = "";
            var paramsList = new List<string>();

            for(int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith('-'))
                {
                    if (IsValidCommand(args[i]))
                    {
                        currentCommand = args[i];
                        paramsList = new List<string>();
                        if (CommandTakesNoParam(currentCommand))
                        {
                            commandsAndParams.Add(currentCommand, paramsList);
                        }
                    } 
                    else
                    {
                        Console.WriteLine(args[i] + " is no know command");
                        return null;
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Please provide a correct argument.");
                        Console.WriteLine("use --help or -h for more information.");
                        return null;
                    }

                    if (CommandTakesNoParam(currentCommand))
                    {
                        Console.WriteLine(currentCommand + " takes no arguments.");
                        return null;
                    }

                    paramsList.Add(args[i]);
                    if (CommandTakesOneParam(currentCommand) && paramsList.Count > 1)
                    {
                        Console.WriteLine(currentCommand + " only takes one argument.");
                        return null;
                    }
                    var checkList = paramsList.ToList();
                    if (!commandsAndParams.TryGetValue(currentCommand, out checkList))
                    {
                        commandsAndParams.Add(currentCommand, paramsList);
                    }
                    else
                    {
                        commandsAndParams[currentCommand] = paramsList;
                    }
                }
            }
            return commandsAndParams;
        }

        public bool IsValidCommand(string command)
        {
            string[] commands = new string[] 
            { 
                "-v", "--version",
                "-h", "--help",
                "-p", "--path",
                "-o", "--output",
                "-f", "--format",
                "-i", "--input" 
            };
            return commands.Contains(command);
        }

        public bool CommandTakesOneParam(string command)
        {
            string[] commands = new string[]
            {
                "-p", "--path",
                "-o", "--output",
                "-f", "--format"
            };
            return commands.Contains(command);
        }

        public bool CommandTakesNoParam(string command)
        {
            string[] commands = new string[]
            {
                "-v", "--version",
                "-h", "--help",
            };
            return commands.Contains(command);
        }
    }
}
