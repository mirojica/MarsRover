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
            command.Replace(" ", "").ToList().ForEach(parsedCommand =>
            {
                if (parsedCommand == 'L' || parsedCommand == 'R')
                    commands.Add(new DirectionCommand(parsedCommand));
                else
                    commands.Add(new PositionCommand());
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
    }

    internal interface IRoverCommand
    {
        void Process(Rover rover);
    }
}
