namespace MarsRover.Application.Surface
{
    public class PlateauSurface : ISurface
    {
        private Size size;

        public void Draw(int width, int height)
        {
            size = new Size(width, height);
        }

        void ISurface.Draw(int width, int height) { Draw(width, height); }

        Size ISurface.Size
        {
            get => size;
            set => size = value;
        }
    }
}
