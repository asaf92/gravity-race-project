using System;

namespace Game.Race
{
    /// <summary>
    /// Holds the game-state and triggers race related events
    /// </summary>
    public class RaceManager : IRaceManager
    {
        public int PlayerPosition { get; }
        public int NumberOfPlayers { get; }
        public int PlayerLap { get; }
        public int NumberOfLaps { get; }
        public float RaceTime { get; private set; }
        public float BestRaceTime { get; }
        //public event EventHandler<RaceFinishedEventArgs> RaceFinishedEvent;

        private IFinishTriggerController _finishTriggerController;
        private readonly IRaceManagerComp _raceManagerComp;

        public RaceManager(int numberOfLaps, int numberOfPlayers, IRaceManagerComp raceManagerComp)
        {

            _raceManagerComp = raceManagerComp ?? throw new ArgumentNullException(nameof(raceManagerComp));
            NumberOfPlayers = numberOfPlayers > 0 ? numberOfPlayers : throw new ArgumentException($"Number of players is less than 1 ({numberOfPlayers})");
            NumberOfLaps = numberOfLaps > 0 ? numberOfLaps : throw new ArgumentException($"Number of laps is less than 1 ({numberOfLaps})");
            PlayerLap = 1;
            RaceTime = 0f;

            _raceManagerComp.RaceTimeUpdate += OnRaceTimeUpdate;
        }

        public void InitFinishTrigger(IFinishTriggerController finishTriggerController)
        {
            _finishTriggerController = finishTriggerController ?? throw new ArgumentNullException(nameof(finishTriggerController));
            _finishTriggerController.LapFinished += OnLapFinished;
        }

        private void OnLapFinished(object sender, LapFinishedEventArgs e)
        {
            _raceManagerComp.RaceTimeUpdate -= OnRaceTimeUpdate;
            //RaceFinishedEvent?.Invoke(this, new RaceFinishedEventArgs());
        }

        private void OnRaceTimeUpdate(object sender, RaceTimeUpdateEventArgs e)
        {
            RaceTime += e.DeltaTime;
        }
    }
}