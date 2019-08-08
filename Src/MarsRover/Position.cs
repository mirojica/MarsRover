namespace MarsRover
{
    public class Position
    {
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

        internal void ChangeDirectionTo(char newDirection) => Direction = newDirection;

        internal void Move()
        {
            switch (Direction)
            {
                case 'N':
                    Y++;
                    break;
                case 'S':
                    Y--;
                    break;
                case 'W':
                    X--;
                    break;
                case 'E':
                    X++;
                    break;
            }
        }
    }
}
