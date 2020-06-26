using MarsRover.Application.Position;
using MarsRover.Application.Surface;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class SurfaceTest : TestBase
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
            surface.Draw(expectedWidth, expectedHeight);

            Assert.AreEqual(expectedWidth, surface.Size.Width);
            Assert.AreEqual(expectedHeight, surface.Size.Height);
        }

        [TestCase(2, 2, 2, 2)]
        [TestCase(3, 4, 0, 0)]
        [TestCase(6, 3, 6, 2)]
        [Test]
        public void IsValid__when_point_is_within_size_boundary_returns_true(int surfaceWidth, int surfaceHeight, int positionX, int positionY)
        {
            surface.Draw(surfaceWidth, surfaceHeight);

            position.Setup(p => p.X).Returns(positionX);
            position.Setup(p => p.Y).Returns(positionY);

            Assert.True(surface.IsValid(position.Object));
        }

        [TestCase(1, 2, 2, 2)]
        [TestCase(3, 4, 6, 0)]
        [TestCase(2, 6, 6, 2)]
        [Test]
        public void IsValid__point_is_outside_size_boundary_returns_false(int surfaceWidth, int surfaceHeight, int positionX, int positionY)
        {
            surface.Draw(surfaceWidth, surfaceHeight);

            position.Setup(p => p.X).Returns(positionX);
            position.Setup(p => p.Y).Returns(positionY);

            Assert.False(surface.IsValid(position.Object));
        }
    }
}
