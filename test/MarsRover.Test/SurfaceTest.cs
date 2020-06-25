using MarsRover.Application.Surface;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class SurfaceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(6, 3)]
        [Test]
        public void Draw__GeneratePlateauSizeWithSameValues(int expectedWidth, int expectedHeight)
        {
            ISurface plateau = new PlateauSurface();
            plateau.Draw(expectedWidth, expectedHeight);

            Assert.AreEqual(expectedWidth, plateau.Size.Width);
            Assert.AreEqual(expectedHeight, plateau.Size.Height);
        }
    }
}
