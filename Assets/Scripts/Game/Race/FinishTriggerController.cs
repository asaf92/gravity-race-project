using System;
using Game.Physics;
using UnityEngine;

namespace Game.Race
{
    public class FinishTriggerController : IFinishTriggerController
    {
        /// <summary>
        /// Raised whenever a vehicle finishes a lap
        /// </summary>
        public event EventHandler<LapFinishedEventArgs> LapFinished;

        /// <summary>
        /// Invokes the <see cref="LapFinished"/> event with <paramref name="gravitySubjectController"/> as the argument
        /// </summary>
        /// <param name="gravitySubjectController">The controller of the gravity subject that entered the trigger</param>
        public void VehicleFinishedLap(IGravitySubjectController gravitySubjectController)
        {
            Debug.Log("Invoking lap finished event");
            if (gravitySubjectController == null) throw new ArgumentNullException(nameof(gravitySubjectController));
            
            LapFinished?.Invoke(this,new LapFinishedEventArgs(gravitySubjectController));
        }
    }

    public class LapFinishedEventArgs: EventArgs
    {
        /// <summary>
        /// The vehicle that finished the lap
        /// </summary>
        public IGravitySubjectController Vehicle { get; set; }

        public LapFinishedEventArgs(IGravitySubjectController gravitySubject)
        {
            Vehicle = gravitySubject ?? throw new ArgumentNullException(nameof(gravitySubject));
        }
    }
}