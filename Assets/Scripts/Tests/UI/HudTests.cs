using Game.Race;
using Game.Race.Events;
using NSubstitute;
using NUnit.Framework;
using Presentation.UI;
using System;

namespace Tests
{
    public class HudTests
    {
        private const int DefaultCountdownTime = 1;
        private const int DefaultSeconds = 28;
        private const int DefaultMinutes = 3;

        private IFinishTimeComp _finishTimeComp;
        private FinishTimeController _finishTimeController;
        private IRaceManager _raceManager;

        [SetUp]
        public void SetUp()
        {
            _raceManager = Substitute.For<IRaceManager>();
            _finishTimeComp = Substitute.For<IFinishTimeComp>();
            _finishTimeController = new FinishTimeController(_finishTimeComp ,_raceManager);
        }

        [Test]
        public void RaceFinished_NotNewRecord_ShowTimeOnScreen()
        {
            TimeSpan finishTime = new TimeSpan(0, DefaultMinutes, DefaultSeconds);
            _raceManager.RaceFinished += Raise.EventWith(new RaceFinishedEventArgs(finishTime, false));

            _finishTimeComp.Received().ShowFinishTime(finishTime);
        }
    }
}
