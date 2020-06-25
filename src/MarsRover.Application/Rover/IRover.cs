using MarsRover.Application.Surface;
using System.Collections.Generic;

namespace MarsRover.Application.Rover
{
    public interface IRover
    {
        IPosition Position { get; }
        void Move(List<Shared.Enums.Movement> movements);
        void Load(ISurface surface, IPosition position);
        bool IsLoad { get; }
    }
}
