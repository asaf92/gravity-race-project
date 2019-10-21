using System;

namespace Game.Race.Events
{
    /// <summary>
    /// Raised when the race has finished
    /// </summary>
    public class RaceFinishedEventArgs : EventArgs
    {
        /// <summary>
        /// The time it took to the player to finish the race
        /// </summary>
        public TimeSpan FinishTime { get; }

        /// <summary>
        /// true if the <see cref="FinishTime"/> a new record
        /// </summary>
        public bool IsNewRecord { get; }

        public RaceFinishedEventArgs(TimeSpan finishTime, bool newRecord)
        {
            FinishTime = finishTime;
            IsNewRecord = newRecord;
        }
    }

    public class FinishTriggerActivated : EventArgs
    {
        public FinishTriggerActivated()
        {

        }
    }
}