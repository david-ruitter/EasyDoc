using EasyDoc.Application.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace EasyDoc.Application.Tests.ServiceTests
{
    public class CommandServiceTests
    {
        private readonly CommandService _commandService;

        public static readonly IEnumerable<object[]> ValidCommands = new List<object[]>()
        {
            new object[]
            {
                new string[]
                {
                    "-v", "--version",
                    "-h", "--help",
                    "-p", "--path",
                    "-o", "--output",
                    "-f", "--format",
                    "-i", "--input",
                    "-e", "--exclude",
                }
            }
        };

        public static readonly IEnumerable<object[]> InvalidCommands = new List<object[]>()
        {
            new object[]
            {
                new string[]
                {
                    "--v", "-version",
                    "abcdefghijk",
                    null,
                    string.Empty,
                }
            }
        };

        public static readonly IEnumerable<object[]> OneParamCommand = new List<object[]>()
        {
            new object[]
            {
                new string[]
                {
                    "-p", "--path",
                    "-o", "--output",
                    "-f", "--format",
                    "-e", "--exclude",
                }
            }
        };

        public static readonly IEnumerable<object[]> NoParamCommands = new List<object[]>()
        {
            new object[]
            {
                new string[]
                {
                    "-v", "--version",
                    "-h", "--help",
                }
            }
        };

        public static readonly IEnumerable<object[]> ConvertInputTestData = new List<object[]>()
        {
            // version command
            new object[]
            {
                new string[]
                {
                    "-v"
                },
                new Dictionary<string, List<string>>()
                {
                    { "-v", new List<string>() }
                }
            },
            // help command
            new object[]
            {
                new string[]
                {
                    "-h"
                },
                new Dictionary<string, List<string>>()
                {
                    { "-h", new List<string>() }
                }
            }
        };

        public static readonly IEnumerable<object[]> NotConvertInputTestData = new List<object[]>()
        {
            // No known Command TestCase
            new object[]
            {
                new string[]
                {
                    "--v"
                },
                new string[]
                {
                    "--v is no know command"
                }
            },
            // Command takes no arguments Test Case
            new object[]
            {
                new string[]
                {
                    "-v", "abcde"
                },
                new string[]
                {
                    "-v takes no arguments."
                }
            },
            new object[]
            {
                new string[]
                {
                    "-h", Path.Combine("C:", "dev", "doc"),
                },
                new string[]
                {
                    "-h takes no arguments."
                },
            },
            // Argument List which starts with an element without "-" prefix
            new object[]
            {
                new string[]
                {
                    "v"
                },
                new string[]
                {
                    "Please provide a correct argument.",
                    "use --help or -h for more information."
                },
            },
            // Command that takes only one argument
            new object[]
            {
                new string[]
                {
                    "-o",
                    Path.Combine("C:", "dev", "doc"),
                    Path.Combine("C:", "dev", "doc2"),
                },
                new string[]
                {
                    "-o only takes one argument."
                },
            },
        };

        public CommandServiceTests()
        {
            _commandService = new CommandService();
        }

        [Theory, MemberData(nameof(ValidCommands))]
        public void Should_Be_Valid_Command(string[] validCommands)
        {
            foreach(var command in validCommands) 
            {
                _commandService.IsValidCommand(command).Should().BeTrue();
            }
        }

        [Theory, MemberData(nameof(InvalidCommands))]
        public void Should_Be_Invalid_Command(string[] invalidCommands)
        {
            foreach (var command in invalidCommands)
            {
                _commandService.IsValidCommand(command).Should().BeFalse();
            }
        }

        [Theory, MemberData(nameof(OneParamCommand))]
        public void Should_Take_One_Param(string[] oneParamCommands)
        {
            foreach (var command in oneParamCommands)
            {
                _commandService.CommandTakesOneParam(command).Should().BeTrue();
            }
        }

        [Theory, MemberData(nameof(NoParamCommands))]
        public void Should_Take_No_Param(string[] noParamCommands)
        {
            foreach (var command in noParamCommands)
            {
                _commandService.CommandTakesNoParam(command).Should().BeTrue();
            }
        }

        [Theory, MemberData(nameof(ConvertInputTestData))]
        public void Should_Convert_Input_To_Commands_And_Params(string[] input, Dictionary<string, List<string>> result)
        {
            _commandService.ConvertInputToCommandsAndParams(input).Should().BeEquivalentTo(result);
        }

        [Theory, MemberData(nameof(NotConvertInputTestData))]
        public void Should_Not_Convert_Input_To_Commands_And_Params(string[] input, string[] errorMessages)
        {
            var actualBuilder = new StringBuilder();
            var actualStringWriter = new StringWriter(actualBuilder);
            Console.SetOut(actualStringWriter);
            _commandService.ConvertInputToCommandsAndParams(input).Should().BeNull();
            string actual = actualBuilder.ToString();

            var expectedBuilder = new StringBuilder();
            var expectedStringWriter = new StringWriter(expectedBuilder);
            Console.SetOut(expectedStringWriter);
            foreach(var errorMessage in errorMessages)
            {
                Console.WriteLine(errorMessage);
            }
            string expected = expectedBuilder.ToString();

            expected.Should().Be(actual);
        }
    }
}
