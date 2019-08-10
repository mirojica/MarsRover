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

        internal IList<IRoverCommand> All() => _commands;

        private static void AssertThatReceivedCommandIsValid(string command)
        {
            var trimedCommand = command.Replace(" ", "");
            if (!Regex.IsMatch(trimedCommand, @"^[LMR]{3}$"))
                throw new ArgumentException("Invalid command.");
        }

        private static List<char> ParseCommandsFrom(string command) => command.Replace(" ", "").ToList();

        private static IRoverCommand CreateACommandBasedOnParsedCommand(char parsedCommand)
        {
            if (parsedCommand == 'L')
                return new LeftDirectionCommand();
            if (parsedCommand == 'R')
                return new RightDirectionCommand();
            return new MoveCommand();
        }
    }

    internal interface IRoverCommand
    {
        void Process(Rover rover);
    }
}
