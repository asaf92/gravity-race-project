using System;
using UnityEngine;

namespace Game.Physics
{
    public class GravitySubjectController : IGravitySubjectController
    {
        private IGravitySubjectComp _component;

        public GravitySubjectController(IGravitySubjectComp component)
        {
            _component = component ?? throw new ArgumentNullException(nameof(component));
        }
       
        public Vector3 Position => _component.Position;

        public void ApplyForce(Vector3 force)
        {
            _component.ApplyForce(force);
        }
    }
}
