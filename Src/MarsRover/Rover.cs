using System;

namespace MarsRover
{
    internal class Rover
    {
        public Rover(int plateuWidth, int plateuHeight)
        {
            Plateu = new Plateu(plateuWidth, plateuHeight);
            Position = Position.Start();
        }

        public Plateu Plateu { get; }
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
