using UnityEngine;

namespace Game.Physics
{
    /// <summary>
    /// Implemented by <see cref="GameObject"/> or components that return their position
    /// </summary>
    public interface IPositional
    {
        /// <summary>
        /// The world-space position of the object
        /// </summary>
        Vector3 Position { get; }
    }
}