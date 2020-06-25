namespace MarsRover.Application.Surface
{
    public interface ISurface
    {
        Size Size { get; set; }
        void Draw(int width, int height);
    }
}
