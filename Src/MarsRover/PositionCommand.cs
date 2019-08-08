namespace MarsRover
{
    internal class PositionCommand : IRoverCommand
    {
        public void Process(Rover rover)
        {
            switch (rover.Position.Direction)
            {
                case 'N':
                    rover.Position.Y++;
                    break;
                case 'S':
                    rover.Position.Y--;
                    break;
                case 'W':
                    rover.Position.X--;
                    break;
                case 'E':
                    rover.Position.X++;
                    break;
            }
        }
    }
}
