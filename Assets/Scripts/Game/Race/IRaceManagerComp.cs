using System;

namespace Game.Race
{
    public interface IRaceManagerComp
    {
        /// <summary>
        /// Reference to the Race Manager class (<see cref="IRaceManagerComp"/> is just the GameObject component and most of the logic is done in the manager itself)
        /// </summary>
        IRaceManager RaceManager { get; }

        /// <summary>
        /// Raised every frame update
        /// </summary>
        event EventHandler<RaceTimeUpdateEventArgs> RaceTimeUpdate;

        /// <summary>
        /// Allows the user to control his car
        /// </summary>
        void AllowUserControl(bool allow);
    }
}