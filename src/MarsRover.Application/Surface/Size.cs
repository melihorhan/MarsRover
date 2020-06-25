namespace MarsRover.Application.Surface
{
    public struct Size
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height) : this()
        {
            Width = width;
            Height = height;
        }
    }
}
