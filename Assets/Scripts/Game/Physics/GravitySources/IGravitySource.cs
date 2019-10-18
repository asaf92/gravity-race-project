using UnityEngine;

namespace Game.Physics.GravitySources
{
    /// <summary>
    /// A <see cref="MonoBehaviour"/> of a gravity source <see cref="GameObject"/>
    /// </summary>
    public interface IGravitySourceComponent : IPositional
    {
        /// <summary>
        /// The power of the gravity in m/s^2
        /// </summary>
        float Strength { get; } 
    }
}
