using UnityEngine;

namespace Game.Physics.GravitySources
{
    public interface ICapsuleGravitySourceComponent: IGravitySourceComponent
    {
        /// <summary>
        /// The direction of the local Z axis of the capsule
        /// </summary>
        Vector3 ForwardDirection { get; }
    }
}
