namespace MarsRover
{
    internal class Rover
    {
        public Rover(int plateauWidth, int plateauHeight)
        {
            Plateau = new Plateau(plateauWidth, plateauHeight);
            Position = Position.Start();
        }

        public Plateau Plateau { get; }
        public Position Position { get; }

        internal void Execute(Commands commands)
        {
            foreach (var command in commands.Next())
                command.Process(this);
        }

        internal void ChangeDirectionTo(char newDirection)
        {
            Position.ChangeDirectionTo(newDirection);
        }
    }
}
