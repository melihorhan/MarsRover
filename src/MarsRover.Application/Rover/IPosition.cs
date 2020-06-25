﻿using MarsRover.Shared.Enums;

namespace MarsRover.Application.Rover
{
    public interface IPosition
    {
        int X { get; }
        int Y { get; }
        CompassDirection Direction { get; }
        IPosition ChangeDirection(CompassDirection direction);
        IPosition ChangePoint(int x, int y);
    }
}
