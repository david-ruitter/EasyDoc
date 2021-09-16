using EasyDoc.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyDoc.Application.Services
{
    public class CommandService : ICommandService
    {
        private Dictionary<string, List<string>> CommandsAndParams = new(); 
        public Dictionary<string, List<string>>? ConvertInteractive()
        {
            // First command is the question
            var commands = new string[] { "Which command do you want to choose", "Run", "Input", "Output", "Help", "Version", "Exit" };
            string? command = GetCommand(commands);
            if (command == null)
            {
                return null;
            }
            switch(command.ToLower())
            {
                case "run":
                    {
                        return CommandsAndParams;
                    }
                case "version":
                    {
                        return new Dictionary<string, List<string>>() { 
                            { "-v", new List<string>() } };
                    }
                case "help":
                    {
                        return new Dictionary<string, List<string>>() { 
                            { "-h", new List<string>() } };
                    }
                case "input":
                    {
                        string? inputPath = GetUserInput();
                        if (inputPath == null)
                        {
                            return null;
                        }
                        CommandsAndParams.Add("-i", new List<string>() { inputPath });
                        return ConvertInteractive();
                    }
                case "output":
                    {
                        string? outputPath = GetUserInput();
                        if (outputPath == null)
                        {
                            return null;
                        }
                        CommandsAndParams.Add("-o", new List<string>() { outputPath });
                        return ConvertInteractive();
                    }
            }
            return null;
        }

        private string? GetUserInput()
        {
            Console.CursorVisible = true;
            Console.Write("> ");
            string? input = Console.ReadLine();
            Console.CursorVisible = false;
            return input;
        }

        private string? GetCommand(string[] commands)
        {
            Console.CursorVisible = false;

            int i = 1;
            int max = commands.Length - 1;
            int min = i;

            UpdateConsole(commands, i);
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (i > min)
                            {
                                i--;
                                UpdateConsole(commands, i);
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (i < max)
                            {
                                i++;
                                UpdateConsole(commands, i);
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            Console.Clear();
                            PrintQuestion($"{commands[0]}? {commands[i]}");
                            return commands[i];
                        }
                }
            }
            while (key.Key != ConsoleKey.Q);
            return null;
        }

        private static void UpdateConsole(string[] commands, int index)
        {
            Console.Clear();
            for (int j = 0; j < commands.Length; j++)
            {
                if (j == index)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"> {commands[j]}");
                    Console.ResetColor();
                }
                else if (j == 0)
                {
                    PrintQuestion(commands[j]);
                }
                else
                {
                    Console.WriteLine($"  {commands[j]}");
                }
            }

            Console.SetCursorPosition(0, index);
        }

        private static void PrintQuestion(string question)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("? ");
            Console.ResetColor();
            Console.WriteLine(question);
        }

        public Dictionary<string, List<string>>? ConvertInputToCommandsAndParams(string[] args)
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
                        Console.WriteLine($"{args[i]} is no know command");
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
                        Console.WriteLine($"{currentCommand} takes no arguments.");
                        return null;
                    }

                    paramsList.Add(args[i]);
                    if (CommandTakesOneParam(currentCommand) && paramsList.Count > 1)
                    {
                        Console.WriteLine($"{currentCommand} only takes one argument.");
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
                "-i", "--input",
                "-e", "--exclude",
            };
            return commands.Contains(command);
        }

        public bool CommandTakesOneParam(string command)
        {
            string[] commands = new string[]
            {
                "-p", "--path",
                "-o", "--output",
                "-f", "--format",
                "-e", "--exclude",
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
