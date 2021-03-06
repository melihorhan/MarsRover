﻿using System;
using System.Text.RegularExpressions;
using MarsRover.Shared.Enums;

namespace MarsRover.Application
{
    public class PositionHandler : IHandler
    {
        private readonly IRoverManager roverManager;

        private Regex CommandPattern => new Regex("^\\d+ \\d+ [NSWE]$");

        public PositionHandler(IRoverManager roverManager)
        {
            this.roverManager = roverManager;
        }

        protected internal bool Match(string command)
        {
            return CommandPattern.IsMatch(command);
        }

        protected internal void Run(string command)
        {

            var commandArray = command.Split(' ');
            var x = int.Parse(commandArray[0]);
            var y = int.Parse(commandArray[1]);
            var direction = Enum.Parse<CompassDirection>(commandArray[2]);

            roverManager.LoadRover(x, y, direction);
        }

        #region Explicitly Implementations

        Regex IHandler.CommandPattern => CommandPattern;

        bool IHandler.Match(string command) { return Match(command); }

        void IHandler.Run(string command) { Run(command); }

        #endregion
    }
}
