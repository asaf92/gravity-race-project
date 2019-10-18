using UnityEngine;

namespace Game.Physics.GravitySources
{
    /// <summary>
    /// A component of a gravity source that pulls all subjects in the same direction
    /// </summary>
    public interface IDirectionalGravitySourceComponent : IGravitySourceComponent
    {
        /// <summary>
        /// The world-space direction that the subjects will be pulled to
        /// </summary>
        Vector3 GravityPullDirection { get; }

        Vector3 SurfaceNormal { get; }
    }
}