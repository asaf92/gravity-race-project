using Game.Constants;
using Game.Race.Events;
using System;
using UnityEngine;

namespace Game.Race
{
    /// <summary>
    /// Holds the game-state and triggers race related events
    /// </summary>
    public class RaceManager : IRaceManager
    {
        private const int DefaultCountdownTime = 3;

        public int PlayerPosition { get; }
        public int NumberOfPlayers { get; }
        public int PlayerLap { get; }
        public int NumberOfLaps { get; }
        public float RaceTime { get; private set; }
        public float BestRaceTime { get; }

        /// <summary>
        /// The time to start the race (in seconds)
        /// </summary>
        public float TimeToStartRace { get; private set; }

        private readonly IRaceManagerComp _raceManagerComp;
        private IFinishTriggerController _finishTriggerController;
        private bool _raceStarted = false;

        public event EventHandler<RaceStartCountdownStartingEventArgs> RaceStartCountdownStarting;
        public event EventHandler<RaceStartedEventArgs> RaceStarted;
        public event EventHandler<RaceFinishedEventArgs> RaceFinished;
        public event EventHandler<NewRecordEventArgs> NewRecordSet;

        public RaceManager(int numberOfLaps, 
            int numberOfPlayers, 
            IRaceManagerComp raceManagerComp, 
            int countdownTimeSeconds = DefaultCountdownTime,
            float bestTime = 0)
        {
            _raceManagerComp = raceManagerComp ?? throw new ArgumentNullException(nameof(raceManagerComp));
            NumberOfPlayers = numberOfPlayers > 0 ? numberOfPlayers : throw new ArgumentException($"Number of players is less than 1 ({numberOfPlayers})");
            NumberOfLaps = numberOfLaps > 0 ? numberOfLaps : throw new ArgumentException($"Number of laps is less than 1 ({numberOfLaps})");
            PlayerLap = 1;
            RaceTime = 0f;
            TimeToStartRace = countdownTimeSeconds;

            _raceManagerComp.RaceTimeUpdate += OnUpdate;

            if(bestTime == 0.0f)
            {
                BestRaceTime = PlayerPrefs.GetFloat(SettingsKeys.HighScore);
                Debug.Log($"Setting best race time to {bestTime}");
            }
        }

        public void InitFinishTrigger(IFinishTriggerController finishTriggerController)
        {
            _finishTriggerController = finishTriggerController ?? throw new ArgumentNullException(nameof(finishTriggerController));
            _finishTriggerController.RaceFinished += OnRaceFinished;
        }

        private void OnRaceFinished(object sender, FinishTriggerActivated e)
        {
            _raceManagerComp.RaceTimeUpdate -= OnUpdate;
            bool newRecord = BestRaceTime <= 0.0f || RaceTime < BestRaceTime;

            RaceFinished?.Invoke(this, new RaceFinishedEventArgs(TimeSpan.FromSeconds(RaceTime), newRecord));
            if(newRecord)
            {
                PlayerPrefs.SetFloat(SettingsKeys.HighScore, RaceTime);
                NewRecordSet?.Invoke(this, new NewRecordEventArgs(RaceTime));
            }

            _raceManagerComp.AllowUserControl(false);
            _raceManagerComp.EndLevel();
        }

        private void OnUpdate(object sender, RaceTimeUpdateEventArgs e)
        {
            if (_raceStarted)
            {
                RaceTime += e.DeltaTime;
            }
            else
            {
                TimeToStartRace -= e.DeltaTime;
                RaceStartCountdownStarting?.Invoke(this, new RaceStartCountdownStartingEventArgs(TimeSpan.FromSeconds(TimeToStartRace)));
                if (TimeToStartRace <= 0)
                {
                    StartRace();
                }
            }
        }

        private void StartRace()
        {
            _raceStarted = true;
            RaceStarted?.Invoke(this, new RaceStartedEventArgs());
            _raceManagerComp.AllowUserControl(true);
        }
    }
}