using System;
using System.Text.RegularExpressions;
using MarsRover.Application.Position;
using MarsRover.Shared.Enums;

namespace MarsRover.Application
{
    public class PositionManager : IHandler<IPosition>
    {
        private Regex CommandPattern => new Regex("^\\d+ \\d+$");

        protected internal IPosition Parse(string command)
        {
            var splitCommand = command.Split(' ');
            var x = int.Parse(splitCommand[0]);
            var y = int.Parse(splitCommand[1]);
            var direction = Enum.Parse<CompassDirection>(splitCommand[2]);
            return new Position.Position(x, y, direction);
        }

        protected internal bool Match(string command)
        {
            return CommandPattern.IsMatch(command);
        }


        #region Explicitly Implementations

        IPosition IHandler<IPosition>.Parse(string command) { return Parse(command); }

        Regex IHandler<IPosition>.CommandPattern => CommandPattern;

        bool IHandler<IPosition>.Match(string command) { return Match(command); }

        #endregion
    }
}
