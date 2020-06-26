using System;
using System.Collections.Generic;
using MarsRover.Application.Position;
using MarsRover.Shared.Enums;

namespace MarsRover.Application.Movement
{
    public static class PossibleRoteteActions
    {
        private static readonly IDictionary<CompassDirection, CompassDirection> LeftTurnDirections = new Dictionary<CompassDirection, CompassDirection>
        {
            { CompassDirection.N, CompassDirection.W },
            { CompassDirection.S, CompassDirection.E },
            { CompassDirection.E, CompassDirection.N },
            { CompassDirection.W, CompassDirection.S },
        };

        private static readonly IDictionary<CompassDirection, CompassDirection> RightTurnDirections = new Dictionary<CompassDirection, CompassDirection>
        {
            { CompassDirection.N, CompassDirection.E },
            { CompassDirection.S, CompassDirection.W },
            { CompassDirection.E, CompassDirection.S },
            { CompassDirection.W, CompassDirection.N },
        };


        private static readonly Dictionary<CompassDirection, Func<IPosition, IPosition>> ForwardDirections = new Dictionary<CompassDirection, Func<IPosition, IPosition>>
        {
            { CompassDirection.N, (p)=> p.ChangePoint(p.X, p.Y + 1) },
            { CompassDirection.S, (p)=>p.ChangePoint(p.X, p.Y - 1) },
            { CompassDirection.E, (p)=>p.ChangePoint(p.X + 1, p.Y) },
            { CompassDirection.W, (p)=>p.ChangePoint(p.X - 1, p.Y)},
        };

        public static readonly IDictionary<Shared.Enums.Movement, Func<IPosition, IPosition>> MovementActions = new Dictionary<Shared.Enums.Movement, Func<IPosition, IPosition>>()
        {
            {Shared.Enums.Movement.L, (p) => p.ChangeDirection(LeftTurnDirections[p.Direction]) },
            {Shared.Enums.Movement.R, (p) => p.ChangeDirection(RightTurnDirections[p.Direction]) },
            {Shared.Enums.Movement.M, (p) => ForwardDirections[p.Direction].Invoke(p)}
        };
    }
}
