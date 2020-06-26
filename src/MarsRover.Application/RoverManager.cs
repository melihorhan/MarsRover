using MarsRover.Application.Rover;
using MarsRover.Application.Surface;
using MarsRover.Shared.Enums;
using System.Collections.Generic;

namespace MarsRover.Application
{
    public class RoverManager : IRoverManager
    {
        private readonly ISurface surface;
        private readonly List<IRover> rovers;
        private IRover currentRover;

        public RoverManager(ISurface surface)
        {
            this.surface = surface;
            this.rovers = new List<IRover>();
        }

        protected internal void LoadRover(int x, int y, CompassDirection direction)
        {
            IRover rover = new RoboticRover();
            rover.Load(surface, new Position.Position(x, y, direction));
            rovers.Add(rover);
            currentRover = rover;
        }

        #region Explicitly Implementations

        ISurface IRoverManager.Surface => surface;

        List<IRover> IRoverManager.Rovers => rovers;

        IRover IRoverManager.CurrentRover => currentRover;

        void IRoverManager.LoadRover(int x, int y, CompassDirection direction) { LoadRover(x, y, direction); }

        #endregion
    }
}
