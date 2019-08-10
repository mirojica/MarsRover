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

            commands.All().Count.Should().Be(3);
        }

        [Fact]
        public void Create_Commands()
        {
            var commands = Commands.From("RML").All();

            commands[0].Should().BeOfType(typeof(RightDirectionCommand));
            commands[1].Should().BeOfType(typeof(MoveCommand));
            commands[2].Should().BeOfType(typeof(LeftDirectionCommand));
        }
    }
}
