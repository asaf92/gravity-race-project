namespace Game.Race
{
    /// <summary>
    /// Holds the game-state and triggers race related events
    /// </summary>
    public interface IRaceManager
    {
        int NumberOfLaps { get; }
        int NumberOfPlayers { get; }
        int PlayerLap { get; }
        int PlayerPosition { get; }
        float RaceTime { get; }
        float BestRaceTime { get; }
        void InitFinishTrigger(IFinishTriggerController finishTriggerController);
    }
}