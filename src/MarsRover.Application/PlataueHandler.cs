using System.Text.RegularExpressions;
using MarsRover.Application.Surface;

namespace MarsRover.Application
{
    public class PlataueHandler : IHandler<Size>
    {
        private Regex CommandPattern => new Regex("^\\d+ \\d+$");

        protected internal static Size Parse(string command)
        {
            var splitCommand = command.Split(' ');
            return new Size(int.Parse(splitCommand[0]), int.Parse(splitCommand[0]));
        }

        protected internal bool Match(string command)
        {
            return CommandPattern.IsMatch(command);
        }

        #region Explicitly Implementations


        Regex IHandler<Size>.CommandPattern => throw new System.NotImplementedException();

        Size IHandler<Size>.Parse(string command) { return Parse(command); }

        bool IHandler<Size>.Match(string command) { return Match(command); }

        #endregion
    }
}
