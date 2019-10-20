using System;
using Game.Physics;
using Game.Race;
using Game.Race.Events;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    public class RaceManagerTests
    {
        // Constants
        private const int NumberOfPlayers = 1;
        private const int NumberOfLaps = 3;
        private const float Epsilon = 0.0000001f;
        private const float FrameDelta = 0.05f;

        // Private Fields
        private IFinishTriggerController _finishTrigger;
        private IRaceManagerComp _raceManagerComp;
        private RaceManager _raceManager;

        [SetUp]
        public void SetUp()
        {
            _finishTrigger = Substitute.For<IFinishTriggerController>();
            _raceManagerComp = Substitute.For<IRaceManagerComp>();
            _raceManager = new RaceManager(NumberOfLaps, NumberOfPlayers, _raceManagerComp);
            _raceManager.InitFinishTrigger(_finishTrigger);
        }

        [Test]
        public void RaceManager_NegativeNumberOfLaps_Throws() => Assert.Throws<ArgumentException>(() =>
        {
            new RaceManager(-1, NumberOfPlayers, _raceManagerComp);
        });

        [Test]
        public void RaceManager_NegativeNumberOfPlayers_Throws() => Assert.Throws<ArgumentException>(() =>
        {
            new RaceManager(NumberOfLaps, -1, _raceManagerComp);
        });

        [Test]
        public void RaceManager_WrongNumberOfLaps_Throws() => Assert.Throws<ArgumentException>(() =>
        {
            new RaceManager(0, NumberOfPlayers, _raceManagerComp);
        });

        [Test]
        public void RaceManager_WrongNumberOfPlayers_Throws() => Assert.Throws<ArgumentException>(() =>
        {
            new RaceManager(NumberOfLaps, 0, _raceManagerComp);
        });

        [Test]
        public void RaceManager_ComponentIsNull_Throws() => Assert.Throws<ArgumentNullException>(() =>
        {
            new RaceManager(NumberOfLaps, NumberOfPlayers, null);
        });

        [Test]
        public void RaceManager_InitialRaceTimeIsZero()
        {
            var raceManager = new RaceManager(NumberOfLaps, 1, _raceManagerComp);
            Assert.IsTrue(raceManager.RaceTime == 0f);
        }

        [Test]
        public void OnComponentRaceTimeUpdateEvent_RaceStarted_TimeGetsUpdated()
        {
            StartRace();
            _raceManagerComp.RaceTimeUpdate += Raise.EventWith(new RaceTimeUpdateEventArgs(FrameDelta));

            Assert.IsTrue(CompareFloats(FrameDelta, _raceManager.RaceTime));
        }

        [Test]
        public void RaceManager_OnRaceFinished_StopsAddingTime()
        {
            _finishTrigger.RaceFinished += Raise.EventWith(new RaceFinishedEventArgs());
            _raceManagerComp.RaceTimeUpdate += Raise.EventWith(new RaceTimeUpdateEventArgs(FrameDelta));
            Assert.Zero(_raceManager.RaceTime);
        }

        [Test]
        public void OnRaceStartCountdown_CountingDown_FiresCountDownEvent()
        {
            var eventRaised = false;
            _raceManager.RaceStartCountdownStarting += (object o, RaceStartCountdownStartingEventArgs e) => { eventRaised = true; };

            _raceManagerComp.RaceTimeUpdate += Raise.EventWith(new RaceTimeUpdateEventArgs(FrameDelta));

            Assert.IsTrue(eventRaised);
        }

        [Test]
        public void OnRaceStartCountdown_FinishedCounting_RaisedEvent()
        {
            var eventRaised = false;
            _raceManager.RaceStarted += (object o, RaceStartedEventArgs e) => { eventRaised = true; };

            StartRace();

            Assert.IsTrue(eventRaised);
        }

        private bool CompareFloats(float a, float b) => Math.Abs(a - b) < Epsilon ? true : false;

        private void StartRace()
        {
            _raceManagerComp.RaceTimeUpdate += Raise.EventWith(new RaceTimeUpdateEventArgs(_raceManager.TimeToStartRace));
        }
    }
}
