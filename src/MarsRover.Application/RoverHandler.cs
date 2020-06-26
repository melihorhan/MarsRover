using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover.Application
{
    public class RoverHandler : IHandler
    {
        private readonly IRoverManager roverManager;

        private Regex CommandPattern => new Regex("^[LMR]+$");

        public RoverHandler(IRoverManager roverManager)
        {
            this.roverManager = roverManager;
        }

        protected internal bool Match(string command)
        {
            return CommandPattern.IsMatch(command);
        }

        protected internal void Run(string command)
        {
            roverManager.CurrentRover?.Move(command.Select(c => Enum.Parse<Shared.Enums.Movement>(c.ToString())).ToList());
        }

        #region Explicitly Implementations

        Regex IHandler.CommandPattern => CommandPattern;

        bool IHandler.Match(string command) { return Match(command); }

        void IHandler.Run(string command) { Run(command); }

        #endregion
    }
}
