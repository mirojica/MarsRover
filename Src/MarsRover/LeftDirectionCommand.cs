namespace MarsRover
{
    internal class LeftDirectionCommand : IRoverCommand
    {
        public void Process(Rover rover) => rover.TurnLeft();
    }
}
