namespace MarsRover
{
    internal class RightDirectionCommand : IRoverCommand
    {
        public void Process(Rover rover) => rover.TurnRight();
    }
}