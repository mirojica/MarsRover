using System.Collections.Generic;

namespace MarsRover
{
    public class Position
    {
        private IDictionary<char, char> _right = new Dictionary<char, char>
            {
                { 'N', 'E' }, { 'W', 'N'}, { 'E', 'S' }, { 'S', 'W' }

            };
        private IDictionary<char, char> _left = new Dictionary<char, char>
            {
                { 'N', 'W' }, { 'W', 'S'}, { 'E', 'N' }, { 'S', 'E' }

            };

        public int X { get; private set; }
        public int Y { get; private set; }
        public char Direction { get; private set; }

        public Position(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        internal static Position Start() => new Position(0, 0, 'N');

        internal Position ToRight() => new Position(X, Y, _right[Direction]);

        internal Position ToLeft() => new Position(X, Y, _left[Direction]);

        internal Position Move()
        {
            int newX = X, newY = Y;
            switch (Direction)
            {
                case 'N':
                    newY++;
                    break;
                case 'S':
                    newY--;
                    break;
                case 'W':
                    newX--;
                    break;
                case 'E':
                    newX++;
                    break;
            }

            if (newX < 0 || newY < 0)
                throw new OutOfPlateauException();

            return new Position(newX, newY, Direction);
        }
    }
}
