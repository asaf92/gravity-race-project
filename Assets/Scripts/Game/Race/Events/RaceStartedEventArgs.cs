using System;

namespace Game.Race.Events
{
    public class RaceStartedEventArgs : EventArgs
    {
    }

    public class RaceStartCountdownStartingEventArgs : EventArgs
    {
        public TimeSpan TimeLeft { get; }

        public RaceStartCountdownStartingEventArgs(TimeSpan timeLeft)
        {
            TimeLeft = timeLeft;
        }
    }
}
