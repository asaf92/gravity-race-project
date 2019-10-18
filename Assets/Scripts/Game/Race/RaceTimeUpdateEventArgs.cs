using System;
using UnityEngine;

namespace Game.Race
{
    public class RaceTimeUpdateEventArgs: EventArgs
    {
        private float time;

        /// <summary>
        /// The time passed since last frame (<see cref="Time.deltaTime"/>)
        /// </summary>
        public float DeltaTime { get; }

        public RaceTimeUpdateEventArgs(float time)
        {
            DeltaTime = time;
        }
    }
}