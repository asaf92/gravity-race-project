using UnityEngine;

namespace Game.Physics
{
    public interface IGravitySubjectComp: IPositional
    {
        IGravitySubjectController Controller { get; }
        float Mass { get; }
        
        /// <summary>
        /// Applies gravitational force on the subject
        /// </summary>
        /// <param name="force">The vector (with magnitude) of the force to be applied</param>
        void ApplyForce(Vector3 force);
    }
}