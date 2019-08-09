using System;
using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverShould
    {
        [Fact]
        public void Be_placed_on_a_plateau_of_a_specific_size()
        {
            var rover = Rover.OnAPlateauSize(5, 5);

            rover.Plateau.Should().BeEquivalentTo(Plateau.Size(5, 5));
        }

        [Fact]
        public void Be_placed_on_a_starting_position_at_a_begining()
        {
            var rover = Rover.OnAPlateauSize(5, 5);

            rover.Position.Should().BeEquivalentTo(Position.Start());
        }

        [Theory]
        [InlineData(1, 0, 'N', "R M L")]
        [InlineData(0, 2, 'E', "M M R")]
        [InlineData(2, 0, 'E', "R M M")]
        public void Get_to_a_new_position_after_command(int xPosition, int yPosition, char direction, string receivedCommand)
        {
            var commands = Commands.From(receivedCommand);
            var rover = Rover.OnAPlateauSize(6, 6);

            rover.Execute(commands);

            rover.Position.Should().BeEquivalentTo(
                APosition
                .WithX(xPosition)
                .WithY(yPosition)
                .WithDirection(direction)
                .Build());
        }

        [Theory]
        [InlineData("LML")]
        [InlineData("RRM")]
        [InlineData("LLM")]
        public void Indicate_that_sent_command_will_take_it_out_of_plateau(string outOfPlateauCommand)
        {
            var commands = Commands.From(outOfPlateauCommand);
            var rover = Rover.OnAPlateauSize(6, 6);

            Action action = () => rover.Execute(commands);

            action.Should().Throw<OutOfPlateauException>();
        }

        private PositionBuilder APosition => new PositionBuilder();
    }
}
