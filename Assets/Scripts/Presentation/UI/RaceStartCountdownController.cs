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
        private int _secondsLeft;

        public RaceStartCountdownController(IRaceStartCountdownComp component, IRaceManager raceManager)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
            _raceManager = raceManager ?? throw new ArgumentNullException(nameof(raceManager));
            _raceManager.RaceStartCountdownStarting += RaceManager_RaceStartCountdownStartingEvent;
        }

        private void RaceManager_RaceStartCountdownStartingEvent(object sender, RaceStartCountdownStartingEventArgs e)
        {
            if(_secondsLeft == e.TimeLeft.Seconds)
            {
                return;
            }

            _secondsLeft = e.TimeLeft.Seconds;

            if (_secondsLeft == 0)
            {
                _component.SetCountdownDisplay(RaceStartText);
                _component.PlayRaceStartSound();
                _raceManager.RaceStartCountdownStarting -= RaceManager_RaceStartCountdownStartingEvent;
                _component.RemoveCountdownDisplay(CountdownDisplayRemovalDelay);

                return;
            }

            _component.SetCountdownDisplay(_secondsLeft.ToString());
            _component.PlayCountdownSound();
        }
    }
}