using MarsRover.Application.Rover;

namespace MarsRover.Application.Surface
{
    public class PlateauSurface : ISurface
    {
        private Size size;

        protected internal void Draw(int width, int height)
        {
            size = new Size(width, height);
        }

        protected internal bool IsValid(IPosition position)
        {
            return (position.X >= 0 && position.X <= size.Width && position.Y >= 0 && position.Y <= size.Height);
        }


        #region Explicitly Implementations
        void ISurface.Draw(int width, int height) { Draw(width, height); }

        bool ISurface.IsValid(IPosition position) { return IsValid(position); }

        Size ISurface.Size
        {
            get => size;
            set => size = value;
        }
        #endregion
    }
}
