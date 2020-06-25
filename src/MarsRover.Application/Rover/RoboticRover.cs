using System;
using System.Collections.Generic;
using MarsRover.Application.Movement;
using MarsRover.Application.Position;
using MarsRover.Application.Surface;

namespace MarsRover.Application.Rover
{
    public class RoboticRover : IRover
    {

        private IPosition position;
        private bool isLoad;

        protected internal void Load(ISurface surface, IPosition position)
        {
            if (surface == null)
            {
                throw new ArgumentNullException(nameof(surface));
            }

            if (position == null)
            {
                throw new ArgumentNullException();
            }

            if (!surface.IsValid(position))
            {
                throw new OverflowException("yükleme başarısız.");
            }

            this.position = position;

        }

        protected internal void Move(List<Shared.Enums.Movement> movements)
        {
            foreach (var movement in movements)
            {
                RoteteActions.MovementActions[movement].Invoke(position);
            }

        }

        #region Explicitly Implementations

        IPosition IRover.Position => position;

        bool IRover.IsLoad => isLoad;

        void IRover.Move(List<Shared.Enums.Movement> movements) { Move(movements); }

        void IRover.Load(ISurface surface, IPosition position) { Load(surface, position); }

        #endregion
    }
}
