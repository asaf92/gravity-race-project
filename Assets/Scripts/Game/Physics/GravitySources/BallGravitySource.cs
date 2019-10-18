using System;
using UnityEngine;

namespace Game.Physics.GravitySources
{
    public class BallGravitySourceController : IGravitySourceController
    {
        private readonly IGravitySourceComponent _component;
        private readonly IAreaOfEffect<IGravitySubjectController> _areaOfEffect;

        public BallGravitySourceController(IGravitySourceComponent component, IAreaOfEffect<IGravitySubjectController> areaOfEffect)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
            _areaOfEffect = areaOfEffect ?? throw new ArgumentNullException(nameof(areaOfEffect));
        }

        public void PhysicsStep()
        {
            foreach(var subject in _areaOfEffect.ObjectsInTrigger)
            {
                var position = _component.Position;
                var strength = _component.Strength;
                var force = Vector3.Normalize(position - subject.Position) * strength;
                subject.ApplyForce(force);
            }
        }
    }
}