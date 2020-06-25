using System;
using System.Collections.Generic;
using MarsRover.Application.Rover;
using MarsRover.Shared.Enums;

namespace MarsRover.Application.Movement
{
    public static class RoteteAction
    {
        public static Dictionary<CompassDirection, CompassDirection> LeftTurnDirections = new Dictionary<CompassDirection, CompassDirection>
        {
            { CompassDirection.N, CompassDirection.W },
            { CompassDirection.S, CompassDirection.E },
            { CompassDirection.E, CompassDirection.N },
            { CompassDirection.W, CompassDirection.S },
        };

        public static Dictionary<CompassDirection, CompassDirection> RightTurnDirections = new Dictionary<CompassDirection, CompassDirection>
        {
            { CompassDirection.N, CompassDirection.E },
            { CompassDirection.S, CompassDirection.W },
            { CompassDirection.E, CompassDirection.S },
            { CompassDirection.W, CompassDirection.N },
        };


        public static IDictionary<Shared.Enums.Movement, Func<IPosition, IPosition>> MovementActions = new Dictionary<Shared.Enums.Movement, Func<IPosition, IPosition>>()
        {
            {Shared.Enums.Movement.L, (p) => p.ChangeDirection(LeftTurnDirections[p.Direction]) },
            {Shared.Enums.Movement.R, (p) => p.ChangeDirection(RightTurnDirections[p.Direction]) },
            {
                Shared.Enums.Movement.M, (p) =>
                {
                    if (p.Direction == CompassDirection.N)
                    {
                        p.ChangePoint(p.X, p.Y + 1);
                    }

                    else if (p.Direction == CompassDirection.E)
                    {
                        p.ChangePoint(p.X + 1, p.Y);
                    }

                    else if (p.Direction == CompassDirection.S)
                    {
                        p.ChangePoint(p.X, p.Y - 1);
                    }
                    else if (p.Direction == CompassDirection.W)
                    {
                        p.ChangePoint(p.X - 1, p.Y);
                    }

                    return p;
                }
            }
        };
    }
}
