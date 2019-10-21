using System;
using Game.Physics;
using Game.Race.Events;

namespace Game.Race
{
    public class FinishTriggerController : IFinishTriggerController
    {
        /// <summary>
        /// Raised whenever a vehicle finishes a lap
        /// </summary>
        public event EventHandler<FinishTriggerActivated> RaceFinished;

        /// <summary>
        /// Invokes the <see cref="RaceFinished"/> event with <paramref name="gravitySubjectController"/> as the argument
        /// </summary>
        /// <param name="gravitySubjectController">The controller of the gravity subject that entered the trigger</param>
        public void VehicleFinishedRace(IGravitySubjectController gravitySubjectController)
        {
            if (gravitySubjectController == null) throw new ArgumentNullException(nameof(gravitySubjectController));
            
            RaceFinished?.Invoke(this,new FinishTriggerActivated());
        }
    }
}