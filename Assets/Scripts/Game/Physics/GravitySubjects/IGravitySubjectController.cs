using UnityEngine;

namespace Game.Physics
{
    public interface IGravitySubjectController: IPositional
    {
        /// <summary>
        /// Applies gravitational acceleration
        /// </summary>
        /// <param name="gravityPull">A non-normalized vector indicating the direction and magnitude of the pull</param>
        void ApplyForce(Vector3 force);
    }
}