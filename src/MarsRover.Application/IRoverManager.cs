using System.Collections.Generic;
using MarsRover.Application.Rover;
using MarsRover.Application.Surface;
using MarsRover.Shared.Enums;

namespace MarsRover.Application
{
    public interface IRoverManager
    {
        ISurface Surface { get; }

        List<IRover> Rovers { get; }

        IRover CurrentRover { get; }

        void LoadRover(int x, int y, CompassDirection direction);
    }
}
