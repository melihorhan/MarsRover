using MarsRover.Shared.Enums;

namespace MarsRover.Application.Rover
{
    public class Position : IPosition
    {
        public int X { get; }

        public int Y { get; }

        public CompassDirection Direction { get; }

        public Position(int x, int y, CompassDirection direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        int IPosition.X => X;

        int IPosition.Y => Y;

        CompassDirection IPosition.Direction => Direction;
    }
}
