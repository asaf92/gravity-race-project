using System;
using UnityEngine;

namespace Game.Physics.GravitySources
{
    public class DirectionalGravitySourceController : IGravitySourceController
    {
        private readonly IDirectionalGravitySourceComponent _component;
        private readonly IAreaOfEffect<IGravitySubjectController> _areaOfEffectTrigger;

        public DirectionalGravitySourceController(IDirectionalGravitySourceComponent component, IAreaOfEffect<IGravitySubjectController> areaOfEffectTrigger)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
            _areaOfEffectTrigger = areaOfEffectTrigger ?? throw new ArgumentNullException(nameof(areaOfEffectTrigger));
        }

        /// <summary>
        /// Runs every fixed update
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the reference to the gravity subjects in the AOE trigger is null</exception>
        public void PhysicsStep()
        {
            var subjects = _areaOfEffectTrigger?.ObjectsInTrigger ?? throw new InvalidOperationException($"Gravity subjects reference is null");
            
            var force = Vector3.Normalize(_component.GravityPullDirection) * _component.Strength;
            foreach (var subject in subjects)
            {
                subject.ApplyForce(force);
            }
        }
    }
}