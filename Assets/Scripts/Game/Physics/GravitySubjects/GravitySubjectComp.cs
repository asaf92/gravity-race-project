using System;
using UnityEngine;

namespace Game.Physics
{
    public class GravitySubjectComp : MonoBehaviour, IGravitySubjectComp
    {
        /// <summary>
        /// Returns the rigidbody component mass
        /// </summary>
        public float Mass => _rigidBodyComponent.mass;

        /// <summary>
        /// World space location
        /// </summary>
        public Vector3 Position => transform.position;

        public IGravitySubjectController Controller { get; private set; }

        private Rigidbody _rigidBodyComponent;
        private void Start()
        {
            _rigidBodyComponent = GetComponent<Rigidbody>();
            if (_rigidBodyComponent == null)
            {
                Debug.LogError("RigidBody component not found");
                enabled = false;
            }

            Controller = new GravitySubjectController(this);
        }

        /// <summary>
        /// Applies gravitational acceleration
        /// </summary>
        /// <param name="gravityPull">A non-normalized vector indicating the direction and magnitude of the pull</param>
        /// <exception cref="InvalidOperationException">Thrown if the Rigidbody component is missing</exception>
        public void ApplyForce(Vector3 gravityPull)
        {
            if (_rigidBodyComponent == null) throw new InvalidOperationException($"Rigidbody component missing");

            _rigidBodyComponent.AddForce(gravityPull, ForceMode.Acceleration);
        }
    }
}

//private IGravitySubject _gravitySubject;
//private IGravitySourcesContainer _gravitySourcesContainer;

//public GravitySubjectController(IGravitySubject gravitySubject)
//{
//    _gravitySubject = gravitySubject ?? throw new ArgumentNullException(nameof(gravitySubject));
//    _gravitySourcesContainer = gravitySubject.GravitySources ?? throw new ArgumentNullException(nameof(gravitySubject.GravitySources));
//}

//public void PhysicsStep()
//{
//    foreach (IGravitySource gravitySource in _gravitySourcesContainer.GravitySourcesList)
//    {
//        // g = GM/R^2
//        // G - General gravity constant
//        // M - Mass
//        // R - Distance
//        var gravityVector = Vector3.Normalize(gravitySource.Direction(_gravitySubject.Position)) *
//            gravitySource.GravityStrength *
//            _gravitySubject.Mass /
//            Mathf.Pow(gravitySource.Distance(_gravitySubject.Position), 2);

//        _gravitySubject.AddForce(gravityVector); 
//    }
//}