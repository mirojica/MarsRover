using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover
{
    internal class Commands
    {
        private readonly IList<IRoverCommand> _commands;

        private Commands(IList<IRoverCommand> commands) => _commands = commands;

        internal static Commands From(string command)
        {
            AssertThatReceivedCommandIsValid(command);
            var commands = ParseCommandsFrom(command).Select(CreateACommandBasedOnParsedCommand).ToList();

            return new Commands(commands);
        }

        internal IEnumerable<IRoverCommand> Next()
        {
            foreach (var command in _commands)
            {
                yield return command;
            }
        }

        private static void AssertThatReceivedCommandIsValid(string command)
        {
            var trimedCommand = command.Replace(" ", "");
            if (!Regex.IsMatch(trimedCommand, @"^[LMR]{3}$"))
                throw new ArgumentException("Invalid command.");
        }

        private static List<char> ParseCommandsFrom(string command) => command.Replace(" ", "").ToList();

        private static IRoverCommand CreateACommandBasedOnParsedCommand(char parsedCommand)
        {
            if (parsedCommand == 'L' || parsedCommand == 'R')
                return new DirectionCommand(parsedCommand);
            return new MoveCommand();
        }
    }

    internal interface IRoverCommand
    {
        void Process(Rover rover);
    }
}
