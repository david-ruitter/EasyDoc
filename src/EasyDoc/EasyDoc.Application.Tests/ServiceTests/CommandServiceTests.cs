using EasyDoc.Application.Services;
using FluentAssertions;
using System.Collections.Generic;
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
    }
}
