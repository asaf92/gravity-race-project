using System;
using Game.Physics;

namespace Game.Race
{
    public interface IFinishTriggerController
    {
        event EventHandler<LapFinishedEventArgs> LapFinished;

        void VehicleFinishedLap(IGravitySubjectController gravitySubjectController);
    }
}