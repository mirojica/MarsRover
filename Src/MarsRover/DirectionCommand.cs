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

        public DirectionCommand(char parsedCommand) => _parsedCommand = parsedCommand;

        public void Process(Rover rover) => rover.ChangeDirectionTo(NewDirectionBasedOnOldFrom(rover));

        private char NewDirectionBasedOnOldFrom(Rover rover)
        {
            if (_parsedCommand == 'R')
            {
                return _right[rover.Position.Direction];
            }
            else if (_parsedCommand == 'L')
            {
                return _left[rover.Position.Direction];
            }

            return 'N';
        }
    }
}
