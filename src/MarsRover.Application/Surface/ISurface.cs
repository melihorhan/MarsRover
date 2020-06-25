using MarsRover.Application.Position;
using MarsRover.Application.Rover;

namespace MarsRover.Application.Surface
{
    public interface ISurface
    {
        Size Size { get; set; }
        void Draw(int width, int height);
        bool IsValid(IPosition position);
    }
}
