namespace MarsRover
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; private set; }

        public Position(int x, int y, char direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        internal static Position Start()
        {
            return new Position(0, 0, 'N');
        }

        internal void ChangeDirectionTo(char newDirection)
        {
            Direction = newDirection;
        }
    }
}
