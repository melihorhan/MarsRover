using System;
using System.Collections.Generic;
using MarsRover.Application.Position;
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
        public void Load__given_valid_deploy_point_and_direction_exposes_as_properties(int expectedX, int expectedY, CompassDirection expectedDirection)
        {
            var expectedPoint = new Position(expectedX, expectedY, expectedDirection);

            mockSurface.Setup(x => x.IsValid(expectedPoint)).Returns(true);

            IRover rover = new RoboticRover();

            rover.Load(mockSurface.Object, expectedPoint);

            Assert.AreEqual(expectedPoint, rover.Position);
        }

        [Test]
        public void Load__after_rover_has_been_loaded_returns_true()
        {
            var position = new Position(0, 0, CompassDirection.S);
            mockSurface.Setup(x => x.IsValid(position)).Returns(true);

            IRover rover = new RoboticRover();

            Assert.IsFalse(rover.IsLoad);
        }

        [Test]
        public void Load__invalid_point_throws_exception()
        {
            var position = new Position(0, 0, CompassDirection.S);

            mockSurface.Setup(x => x.IsValid(position)).Returns(false);
            mockSurface.Setup(x => x.Draw(0, 0));

            IRover rover = new RoboticRover();

            Assert.Throws<OverflowException>(() => rover.Load(mockSurface.Object, position));
        }


        [Test]
        public void Load__before_Rover_has_been_loaded_returns_false_returns_true()
        {
            var position = new Position(0, 0, CompassDirection.S);
            mockSurface.Setup(x => x.IsValid(position)).Returns(true);

            IRover rover = new RoboticRover();
            rover.Load(mockSurface.Object, position);

            Assert.IsTrue(rover.IsLoad);
        }


        [TestCase(1, 1, CompassDirection.S, Movement.R, Movement.R, Movement.M, 1, 2, CompassDirection.N)]
        [TestCase(2, 4, CompassDirection.E, Movement.M, Movement.M, Movement.M, 5, 4, CompassDirection.E)]
        [TestCase(1, 2, CompassDirection.N, Movement.L, Movement.M, Movement.M, 5, 4, CompassDirection.E)]
        public void Move__set_last_position_as_movement_list(int startX, int startY,
            CompassDirection startDirection, Movement firstMove, Movement secondMove, Movement thirdMove,
            int expectedX, int expectedY, CompassDirection expectedDirection)
        {
            var startPosition = new Position(startX, startY, startDirection);
            var movements = new List<Movement> { firstMove, secondMove, thirdMove };

            mockSurface.Setup(x => x.IsValid(startPosition)).Returns(true);

            IRover rover = new RoboticRover();
            rover.Load(mockSurface.Object, startPosition);
            rover.Move(movements);

            Assert.AreEqual(expectedX, rover.Position.X);
            Assert.AreEqual(expectedY, rover.Position.Y);
            Assert.AreEqual(expectedDirection, rover.Position.Direction);
        }
    }
}
