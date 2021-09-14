using EasyDoc.Application.Models;
using FluentAssertions;
using System;
using Xunit;

namespace EasyDoc.Application.Tests.ModelTests
{
    public class ProgressBarTests
    {
        [Fact]
        public void Should_Create_ProgressBar()
        {
            var progressBar = new ProgressBar(10);
            progressBar.Should().NotBeNull();
            progressBar.Length.Should().Be(10);
            progressBar.CurrentStep.Should().Be(0);
            progressBar.ProgressIndicator.Should().Be("#");

            progressBar = new ProgressBar(10, 9);
            progressBar.Should().NotBeNull();
            progressBar.Length.Should().Be(10);
            progressBar.CurrentStep.Should().Be(9);
            progressBar.ProgressIndicator.Should().Be("#");

            progressBar = new ProgressBar(10, 9, "🚀");
            progressBar.Should().NotBeNull();
            progressBar.Length.Should().Be(10);
            progressBar.CurrentStep.Should().Be(9);
            progressBar.ProgressIndicator.Should().Be("🚀");
        }

        [Fact]
        public void Should_Not_Create_ProgressBar()
        {
            Assert.Throws<ArgumentException>(() => new ProgressBar(10, 11));
        }

        [Fact]
        public void Should_Update()
        {
            var progressBar = new ProgressBar(10);
            progressBar.CurrentStep.Should().Be(0);

            progressBar.Update().Should().BeTrue();

            progressBar.CurrentStep.Should().Be(1);
        }

        [Fact]
        public void Should_Not_Update()
        {
            var progressBar = new ProgressBar(10, 10);
            progressBar.CurrentStep.Should().Be(10);

            progressBar.Update().Should().BeFalse();

            progressBar.CurrentStep.Should().Be(10);
        }

        [Fact]
        public void Should_Get_Progress()
        {
            var progressBar = new ProgressBar(10);
            progressBar.GetProgress().Should().Be("          ");

            progressBar.Update().Should().BeTrue();
            progressBar.GetProgress().Should().Be("#         ");

            progressBar = new ProgressBar(10, 2, "🚀");
            progressBar.GetProgress().Should().Be("🚀🚀        ");
        }
    }
}
