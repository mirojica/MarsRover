using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class CommandsShould
    {
        [Theory]
        [InlineData("R M K")]
        [InlineData("RK")]
        [InlineData("J")]
        [InlineData("JLLM")]
        public void Fail_when_receive_invalid_command(string invalidCommand)
        {
            Action action = () => Commands.From(invalidCommand);

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("R M L")]
        [InlineData("RLM")]
        [InlineData("R M    M")]
        public void Successfuly_receive_valid_command(string validCommand)
        {
            var commands = Commands.From(validCommand);

            commands.Should().NotBeNull();
        }
    }
}
