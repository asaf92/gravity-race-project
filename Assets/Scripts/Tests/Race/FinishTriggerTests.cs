using System;
using Game.Physics;
using Game.Race;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class FinishTriggerTests
    {
        private IFinishTriggerController _controller;
        private EventHandler<LapFinishedEventArgs> _lapFinishedEvent;
        private bool _eventRaised;

        [SetUp]
        public void SetUp()
        {
            _controller = new FinishTriggerController();
            _eventRaised = false;
        }

        [Test]
        public void FinishTrigger_LapFinished_RaisesEvent()
        {
            _controller.LapFinished += onLapFinished;
            IGravitySubjectController gravitySubjectController = Substitute.For<IGravitySubjectController>();

            Assert.IsFalse(_eventRaised);
            _controller.VehicleFinishedLap(gravitySubjectController);
            Assert.IsTrue(_eventRaised);
        }

        [Test]
        public void FinishTrigger_VehicleEnteredTriggerIsNull_Throws() => Assert.Throws<ArgumentNullException>(() =>
        {
            _controller.VehicleFinishedLap(null);
        });

        [Test]
        public void FinishTriggerEventArgs_ArgumentIsNull_Throws() => Assert.Throws<ArgumentNullException>(()=>
        {
            new LapFinishedEventArgs(null);
        });

        private void onLapFinished(object sender, LapFinishedEventArgs e)
        {
            _eventRaised = true;
        }
    }
}
