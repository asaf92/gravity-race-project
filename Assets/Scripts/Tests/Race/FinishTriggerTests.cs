using System;
using Game.Physics;
using Game.Race;
using Game.Race.Events;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class FinishTriggerTests
    {
        private IFinishTriggerController _controller;
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
            _controller.RaceFinished += OnLapFinished;
            IGravitySubjectController gravitySubjectController = Substitute.For<IGravitySubjectController>();

            Assert.IsFalse(_eventRaised);
            _controller.VehicleFinishedRace(gravitySubjectController);
            Assert.IsTrue(_eventRaised);
        }

        [Test]
        public void FinishTrigger_VehicleEnteredTriggerIsNull_Throws() => Assert.Throws<ArgumentNullException>(() =>
        {
            _controller.VehicleFinishedRace(null);
        });

        private void OnLapFinished(object sender, FinishTriggerActivated e)
        {
            _eventRaised = true;
        }
    }
}
