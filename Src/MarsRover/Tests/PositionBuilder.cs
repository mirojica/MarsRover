namespace MarsRover.Tests
{
    internal class PositionBuilder
    {
        private int _x;
        private int _y;
        private char _direction;

        internal Position Build() => new Position(_x, _y, _direction);

        internal PositionBuilder WithDirection(char direction)
        {
            _direction = direction;
            return this;
        }

        internal PositionBuilder WithX(int x)
        {
            _x = x;
            return this;
        }

        internal PositionBuilder WithY(int y)
        {
            _y = y;
            return this;
        }
    }
}
