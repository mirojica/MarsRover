namespace MarsRover
{
    internal class DirectionCommand : IRoverCommand
    {
        private readonly char _parsedCommand;
        public DirectionCommand(char parsedCommand) => _parsedCommand = parsedCommand;

        public void Process(Rover rover)
        {
            if (_parsedCommand == 'R')
            {
                rover.TurnRight();
            }
            else
            {
                rover.TurnLeft();
            }
        }
    }
}
