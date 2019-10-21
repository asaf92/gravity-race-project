using System;

namespace Game.Race
{
    public class NewRecordEventArgs : EventArgs
    {
        public float NewRecord { get; }

        public NewRecordEventArgs(float newRecord)
        {
            NewRecord = newRecord;
        }
    }
}