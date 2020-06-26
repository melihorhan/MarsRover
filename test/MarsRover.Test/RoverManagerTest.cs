using NUnit.Framework;

namespace MarsRover.Test
{
    public class RoverManagerTest : TestBase
    {
        [SetUp]
        public void Setup()
        {
            surface.Draw(5, 5);
        }

        [TestCase("1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase("3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void Send__rover_position_is_same_point_with_expected_position(string startPosition, string command, string expectedPosition)
        {
            commandManager.Send(startPosition);
            commandManager.Send(command);

            foreach (var rover in roverManager.Rovers)
            {
                Assert.AreEqual(expectedPosition, $"{rover.Position.X} {rover.Position.Y} {rover.Position.Direction}");
            }
        }
    }
}
