using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Presentation.UI
{
    public class RaceStartCountdownController
    {
        private readonly IRaceStartCountdownComp _component;

        public RaceStartCountdownController(IRaceStartCountdownComp component)
        {
            _component = component;
        }

        public void StartCountdown(int seconds)
        {
            _component.StartCountDown(seconds);
        }
    }
}