namespace MarsRover
{
    internal class Rover
    {
        public Plateau Plateau { get; }
        public Position Position { get; }

        private Rover(int plateauWidth, int plateauHeight)
        {
            Plateau = Plateau.Size(plateauWidth, plateauHeight);
            Position = Position.Start();
        }

        internal static Rover OnAPlateauSize(int plateauWidth, int plateauHeight) => new Rover(plateauWidth, plateauHeight);

        internal void Execute(Commands commands)
        {
            foreach (var command in commands.Next())
                command.Process(this);
        }

        internal void ChangeDirectionTo(char newDirection) => Position.ChangeDirectionTo(newDirection);
    }
}
