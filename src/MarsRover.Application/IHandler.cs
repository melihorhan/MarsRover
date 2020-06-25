using System.Text.RegularExpressions;

namespace MarsRover.Application
{
    public interface IHandler<out T>
    {
        Regex CommandPattern { get; }
        T Parse(string command);
        bool Match(string command);
    }
}
