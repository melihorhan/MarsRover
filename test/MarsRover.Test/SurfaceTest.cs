using MarsRover.Application.Rover;
using MarsRover.Application.Surface;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class SurfaceTest
    {
        private Mock<IPosition> position;

        [SetUp]
        public void Setup()
        {
            position = new Mock<IPosition>();
        }

        [TestCase(2, 2)]
        [TestCase(3, 4)]
        [TestCase(6, 3)]
        [Test]
        public void Draw__generate_plateau_size_with_same_values(int expectedWidth, int expectedHeight)
        {
            ISurface plateau = new PlateauSurface();
            plateau.Draw(expectedWidth, expectedHeight);

            Assert.AreEqual(expectedWidth, plateau.Size.Width);
            Assert.AreEqual(expectedHeight, plateau.Size.Height);
        }

        [TestCase(2, 2, 2, 2)]
        [TestCase(3, 4, 0, 0)]
        [TestCase(6, 3, 6, 2)]
        [Test]
        public void IsValid__when_point_is_within_size_boundary_returns_true(int surfaceWidth, int surfaceHeight, int positionX, int positionY)
        {
            ISurface plateau = new PlateauSurface();
            plateau.Draw(surfaceWidth, surfaceHeight);

            position.Setup(p => p.X).Returns(positionX);
            position.Setup(p => p.Y).Returns(positionY);

            Assert.True(plateau.IsValid(position.Object));
        }

        [TestCase(1, 2, 2, 2)]
        [TestCase(3, 4, 6, 0)]
        [TestCase(2, 6, 6, 2)]
        [Test]
        public void IsValid__point_is_outside_size_boundary_returns_false(int surfaceWidth, int surfaceHeight, int positionX, int positionY)
        {
            ISurface plateau = new PlateauSurface();
            plateau.Draw(surfaceWidth, surfaceHeight);

            position.Setup(p => p.X).Returns(positionX);
            position.Setup(p => p.Y).Returns(positionY);

            Assert.False(plateau.IsValid(position.Object));
        }
    }
}
