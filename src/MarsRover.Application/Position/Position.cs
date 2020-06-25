using MarsRover.Shared.Enums;

namespace MarsRover.Application.Position
{
    public class Position : IPosition
    {
        private int X { get; set; }

        private int Y { get; set; }

        private CompassDirection Direction { get; set; }

        public Position(int x, int y, CompassDirection direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        #region Explicitly Implementations

        int IPosition.X => X;

        int IPosition.Y => Y;

        CompassDirection IPosition.Direction => Direction;

        IPosition IPosition.ChangeDirection(CompassDirection direction)
        {
            Direction = direction;
            return this;
        }

        IPosition IPosition.ChangePoint(int x, int y)
        {
            X = x;
            Y = y;
            return this;
        }

        #endregion
    }
}
