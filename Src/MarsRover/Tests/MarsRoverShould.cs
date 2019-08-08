using FluentAssertions;
using Xunit;

namespace MarsRover.Tests
{
    public class MarsRoverShould
    {
        [Fact]
        public void Be_placed_on_a_plateau_of_a_specific_size()
        {
            var rover = new Rover(5, 5);

            rover.Plateau.Should().BeEquivalentTo(new Plateau(5, 5));
        }

        [Fact]
        public void Be_placed_on_a_starting_position_at_a_begining()
        {
            var rover = new Rover(5, 5);

            rover.Position.Should().BeEquivalentTo(new Position(0, 0, 'N'));
        }

        [Theory]
        [InlineData(1, 0, 'N', "R M L")]
        [InlineData(0, 2, 'E', "M M R")]
        [InlineData(2, 0, 'E', "R M M")]
        public void Get_to_a_new_position_after_command(int xPosition, int yPosition, char direction, string receivedCommand)
        {
            var command = Commands.From(receivedCommand);
            var rover = new Rover(6, 6);

            rover.Execute(command);

            rover.Position.Should().BeEquivalentTo(new Position(xPosition, yPosition, direction));
        }
    }
}
