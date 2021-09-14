using EasyDoc.Application.Models;
using FluentAssertions;
using Xunit;

namespace EasyDoc.Application.Tests.ModelTests
{
    public class CommentTests
    {
        private readonly string _signature = "public static void main(String[] args)";
        private readonly string _content = "This is the entry point of the program";

        [Fact]
        public void Should_Create_Comment()
        {
            var comment = new Comment(
                _signature,
                _content);
            comment.Should().NotBeNull();
        }

        [Fact]
        public void Should_Get_Content()
        {
            var comment = new Comment(
                _signature,
                _content);
            comment.Content.Should().Be(_content);
        }

        [Fact]
        public void Should_Get_Signature()
        {
            var comment = new Comment(
                _signature,
                _content);
            comment.Signature.Should().Be(_signature);
        }

        [Fact]
        public void Should_Set_Content()
        {
            var comment = new Comment("", "")
            {
                Content = _content,
                Signature = _signature
            };
            comment.Content.Should().Be(_content);
            comment.Signature.Should().Be(_signature);
        }
    }
}
