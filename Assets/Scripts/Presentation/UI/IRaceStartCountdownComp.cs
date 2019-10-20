namespace Presentation.UI
{
    public interface IRaceStartCountdownComp
    {
        /// <summary>
        /// Displays the number of seconds left in the countdown
        /// </summary>
        void SetCountdownDisplay(string displayText);

        /// <summary>
        /// Removed the countdown display
        /// </summary>
        /// <param name="delay"></param>
        void RemoveCountdownDisplay(float delay);
    }
}