using Game.Race;
using Game.Race.Events;
using System;

namespace Presentation.UI
{
    public class RaceStartCountdownController
    {
        private const string RaceStartText = "GO!";
        private const int CountdownDisplayRemovalDelay = 3;

        private readonly IRaceStartCountdownComp _component;
        private readonly IRaceManager _raceManager;

        public RaceStartCountdownController(IRaceStartCountdownComp component, IRaceManager raceManager)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
            _raceManager = raceManager ?? throw new ArgumentNullException(nameof(raceManager));
            _raceManager.RaceStartCountdownStarting += RaceManager_RaceStartCountdownStartingEvent;
        }

        private void RaceManager_RaceStartCountdownStartingEvent(object sender, RaceStartCountdownStartingEventArgs e)
        {
            int secondsLeft = e.TimeLeft.Seconds;

            if (secondsLeft == 0)
            {
                _component.SetCountdownDisplay(RaceStartText);
                _raceManager.RaceStartCountdownStarting -= RaceManager_RaceStartCountdownStartingEvent;
                _component.RemoveCountdownDisplay(CountdownDisplayRemovalDelay);

                return;
            }

            _component.SetCountdownDisplay(secondsLeft.ToString());
        }
    }
}