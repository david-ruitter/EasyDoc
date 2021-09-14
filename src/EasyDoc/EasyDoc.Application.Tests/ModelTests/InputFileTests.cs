using EasyDoc.Application.Models;
using FluentAssertions;
using System.IO;
using Xunit;

namespace EasyDoc.Application.Tests.ModelTests
{
    public class InputFileTests
    {
        private readonly string _path = Path.Combine("C:", "dev", "project");
        private readonly string _name = "Main";
        private readonly string _extension = ".java";


        [Fact]
        public void Should_Create_InputFile()
        {
            var inputFile = new InputFile(
                _path,
                _name,
                _extension);

            inputFile.Should().NotBeNull();
        }

        [Fact]
        public void Should_Get_Properties()
        {
            var inputFile = new InputFile(
                _path,
                _name,
                _extension);

            inputFile.Path.Should().Be(_path);
            inputFile.Name.Should().Be(_name);
            inputFile.Extension.Should().Be(_extension);
            inputFile.Content.Should().Be("");
        }


        [Fact]
        public void Should_Set_Properties()
        {
            var inputFile = new InputFile(
                _path,
                _name,
                _extension)
            {
                Path = "Path",
                Name = "Name",
                Extension = "Extension",
                Content = "Content"
            };

            inputFile.Path.Should().Be("Path");
            inputFile.Name.Should().Be("Name");
            inputFile.Extension.Should().Be("Extension");
            inputFile.Content.Should().Be("Content");
        }
    }
}
