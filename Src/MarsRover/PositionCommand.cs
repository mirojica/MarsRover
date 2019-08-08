namespace MarsRover
{
    internal class PositionCommand : IRoverCommand
    {
        public void Process(Rover rover) => rover.Move();
    }
}
