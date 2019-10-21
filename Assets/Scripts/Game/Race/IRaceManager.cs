using Game.Race.Events;
using System;

namespace Game.Race
{
    /// <summary>
    /// Holds the game-state and triggers race related events
    /// </summary>
    public interface IRaceManager
    {
        int NumberOfLaps { get; }
        int NumberOfPlayers { get; }
        int PlayerLap { get; }
        int PlayerPosition { get; }
        float RaceTime { get; }
        float BestRaceTime { get; }
        void InitFinishTrigger(IFinishTriggerController finishTriggerController);

        /// <summary>
        /// Raised when the race start countdown begins
        /// </summary>
        event EventHandler<RaceStartCountdownStartingEventArgs> RaceStartCountdownStarting;

        /// <summary>
        /// Raised when the race begins
        /// </summary>
        event EventHandler<RaceStartedEventArgs> RaceStarted;

        /// <summary>
        /// Raised when the race has finished
        /// </summary>
        event EventHandler<RaceFinishedEventArgs> RaceFinished;
    }
}