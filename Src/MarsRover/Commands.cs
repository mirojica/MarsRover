using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    internal class Commands
    {
        private readonly IList<IRoverCommand> _commands;

        private Commands(IList<IRoverCommand> commands) => _commands = commands;

        internal static Commands From(string command)
        {
            var commands = new List<IRoverCommand>();

            ParseCommandsFrom(command).ForEach(parsedCommand =>
            {
                commands.Add(CreateACommandBasedOn(parsedCommand));
            });

            return new Commands(commands);
        }

        internal IEnumerable<IRoverCommand> Next()
        {
            foreach (var command in _commands)
            {
                yield return command;
            }
        }

        private static List<char> ParseCommandsFrom(string command)
        {
            return command.Replace(" ", "").ToList();
        }

        private static IRoverCommand CreateACommandBasedOn(char parsedCommand)
        {
            if (parsedCommand == 'L' || parsedCommand == 'R')
                return new DirectionCommand(parsedCommand);
            return new PositionCommand();
        }
    }

    internal interface IRoverCommand
    {
        void Process(Rover rover);
    }
}
