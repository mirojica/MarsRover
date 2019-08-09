namespace MarsRover
{
    internal class MoveCommand : IRoverCommand
    {
        public void Process(Rover rover) => rover.Move();
    }
}
