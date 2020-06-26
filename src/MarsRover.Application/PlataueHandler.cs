using System.Text.RegularExpressions;
using MarsRover.Application.Surface;

namespace MarsRover.Application
{
    public class PlataueHandler : IHandler
    {
        private readonly ISurface surface;

        private Regex CommandPattern => new Regex("^\\d+ \\d+$");

        public PlataueHandler(ISurface surface)
        {
            this.surface = surface;
        }

        protected internal bool Match(string command)
        {
            return CommandPattern.IsMatch(command);
        }

        protected internal void Run(string command)
        {
            var splitCommand = command.Split(' ');
            surface.Draw(int.Parse(splitCommand[0]), int.Parse(splitCommand[1]));
        }

        #region Explicitly Implementations


        Regex IHandler.CommandPattern => CommandPattern;

        bool IHandler.Match(string command) { return Match(command); }

        void IHandler.Run(string command) { Run(command); }

        #endregion
    }
}
