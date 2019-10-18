using System;
using UnityEngine;

namespace Game.Physics.GravitySources
{
    public class CapsuleGravitySourceController : IGravitySourceController
    {
        private ICapsuleGravitySourceComponent _component;
        private IAreaOfEffect<IGravitySubjectController> _areaOfEffect;

        public CapsuleGravitySourceController(ICapsuleGravitySourceComponent component, IAreaOfEffect<IGravitySubjectController> areaOfEffect)
        {
            _component = component;
            _areaOfEffect = areaOfEffect;
        }

        /// <summary>
        /// Runs every fixed update
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the reference to the gravity subjects in the AOE trigger is null</exception>
        public void PhysicsStep()
        {
            var subjects = _areaOfEffect?.ObjectsInTrigger ?? throw new InvalidOperationException("Gravity subjects reference is null");
            var capsulePosition = _component.Position;
            var capsuleZAxis = _component.ForwardDirection;
            var gravityStrength = _component.Strength;

            foreach (var subject in subjects)
            {
                var subjectProjection = ProjectPointOnLine(capsulePosition, capsuleZAxis, subject.Position);
                var force = Vector3.Normalize(subjectProjection - subject.Position) * gravityStrength;
                subject.ApplyForce(force);
            }
        }

        /// <summary>
        /// Returns the projection of <paramref name="worldPoint"/> on an infinite line
        /// </summary>
        /// <param name="linePoint">A point on the infinite line</param>
        /// <param name="lineVec">The direction of the infinite line</param>
        /// <param name="worldPoint">The point that's being projected on the line</param>
        /// <returns>World space coordinates of the projection of <paramref name="worldPoint"/> on the line</returns>
        /// <exception cref="ArgumentNullException">Thrown when one of the parameters is null</exception>
        private static Vector3 ProjectPointOnLine(Vector3 linePoint, Vector3 lineVec, Vector3 worldPoint)
        {
            if (linePoint == null || lineVec == null || worldPoint == null) throw new ArgumentNullException();

            var linePointToPoint = worldPoint - linePoint;
            var scalar = Vector3.Dot(linePointToPoint, lineVec);

            return linePoint + lineVec * scalar;
        }
    }
}