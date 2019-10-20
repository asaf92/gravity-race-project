using System;
using Game.Physics;
using Game.Race.Events;

namespace Game.Race
{
    public interface IFinishTriggerController
    {
        event EventHandler<RaceFinishedEventArgs> RaceFinished;

        void VehicleFinishedRace(IGravitySubjectController gravitySubjectController);
    }
}