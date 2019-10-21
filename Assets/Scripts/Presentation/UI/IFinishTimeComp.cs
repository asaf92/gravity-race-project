using System;

namespace Presentation.UI
{
    public interface IFinishTimeComp
    {
        /// <summary>
        /// Displays the finish time
        /// </summary>
        /// <param name="finishTime"></param>
        void ShowFinishTime(TimeSpan finishTime, bool newRecord = false);
    }
}