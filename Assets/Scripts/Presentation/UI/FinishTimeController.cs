using Game.Race;
using Game.Race.Events;
using System;

namespace Presentation.UI
{
    internal class FinishTimeController
    {
        private readonly IFinishTimeComp _component;
        private IRaceManager _raceManager;

        public FinishTimeController(IFinishTimeComp component, IRaceManager raceManager)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
            _raceManager = raceManager ?? throw new ArgumentNullException(nameof(raceManager));
            _raceManager.RaceFinished += OnRaceFinished;
        }

        private void OnRaceFinished(object sender, RaceFinishedEventArgs e)
        {
            _component.ShowFinishTime(e.FinishTime, e.IsNewRecord);
        }
    }
}