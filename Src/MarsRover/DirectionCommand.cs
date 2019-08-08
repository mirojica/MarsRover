using System.Collections.Generic;

namespace MarsRover
{
    internal class DirectionCommand : IRoverCommand
    {
        private readonly char _parsedCommand;
        private IDictionary<char, char> _right = new Dictionary<char, char>
            {
                { 'N', 'E' }, { 'W', 'N'}, { 'E', 'S' }, { 'S', 'W' }

            };
        private IDictionary<char, char> _left = new Dictionary<char, char>
            {
                { 'N', 'W' }, { 'W', 's'}, { 'E', 'N' }, { 'S', 'E' }

            };

        public DirectionCommand(char parsedCommand)
        {
            _parsedCommand = parsedCommand;
        }

        public void Process(Rover rover)
        {
            if (_parsedCommand == 'R')
            {
                rover.ChangeDirectionTo(_right[rover.Position.Direction]);
            }
            else if (_parsedCommand == 'L')
            {
                rover.ChangeDirectionTo(_left[rover.Position.Direction]);
            }
        }
    }
}
