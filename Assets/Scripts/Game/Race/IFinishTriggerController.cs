using System;
using Game.Physics;
using Game.Race.Events;

namespace Game.Race
{
    public interface IFinishTriggerController
    {
        event EventHandler<FinishTriggerActivated> RaceFinished;

        void VehicleFinishedRace(IGravitySubjectController gravitySubjectController);
    }
}