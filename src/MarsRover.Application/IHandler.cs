using System.Text.RegularExpressions;

namespace MarsRover.Application
{
    public interface IHandler
    {
        Regex CommandPattern { get; }
        bool Match(string command);
        void Run(string command);
    }
}
