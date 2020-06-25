using System;
using MarsRover.Application.Rover;
using MarsRover.Application.Surface;
using MarsRover.Shared.Enums;
using Moq;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class RoverTest
    {
        private Mock<ISurface> mockSurface;

        [SetUp]
        public void Setup()
        {
            mockSurface = new Mock<ISurface>();
        }

        [TestCase(1, 2, CompassDirection.W)]
        [TestCase(6, 7, CompassDirection.S)]
        public void Load__given_valid_deploy_point_and_direction_exposes_as_properties(int expectedX, int expectedY, CompassDirection expectedCardinalDirection)
        {
            var expectedPoint = new Position(expectedX, expectedY, expectedCardinalDirection);

            mockSurface.Setup(x => x.IsValid(expectedPoint)).Returns(true);

            IRover rover = new RoboticRover();

            rover.Load(mockSurface.Object, expectedPoint);

            Assert.AreEqual(expectedPoint, rover.Position);
        }

        [Test]
        public void Load__invalid_point_throws_Exception()
        {
            var position = new Position(0, 0, CompassDirection.S);

            mockSurface.Setup(x => x.IsValid(position)).Returns(false);
            mockSurface.Setup(x => x.Draw(0, 0));

            IRover rover = new RoboticRover();

            Assert.Throws<OverflowException>(() => rover.Load(mockSurface.Object, position));
        }
    }
}
