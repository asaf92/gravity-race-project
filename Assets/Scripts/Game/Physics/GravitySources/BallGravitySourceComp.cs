using UnityEngine;

namespace Game.Physics.GravitySources
{
    public class BallGravitySourceComp : MonoBehaviour, IGravitySourceComponent
    {
        /// <summary>
        /// The game object that holds the <see cref="IAreaOfEffect{T}"/> component
        /// </summary>
        [SerializeField]
        private GameObject _areaOfEffectTriggerGameObject;

        /// <summary>
        /// The area-of-effect class that holds all the gravity subjects inside the AOE
        /// </summary>
        private IAreaOfEffect<IGravitySubjectController> _areaOfEffect;

        /// <summary>
        /// World space location 
        /// </summary>
        public Vector3 Position => transform.position;

        /// <summary>
        /// Gravity strength factor
        /// </summary>
        public float Strength => _strength;
        [SerializeField] private float _strength;

        /// <summary>
        /// Radius from which the gravity source does not affect objects
        /// </summary>
        //public float Radius => _radius;
        //[SerializeField] private readonly float _radius;

        /// <summary>
        /// A reference to the controller used to control this humble-object
        /// </summary>
        private IGravitySourceController _controller;
        
        void Start()
        {
            _areaOfEffect = _areaOfEffectTriggerGameObject.GetComponent<IAreaOfEffect<IGravitySubjectController>>();
            _controller = new BallGravitySourceController(this, _areaOfEffect);
        }

        void FixedUpdate()
        {
            _controller.PhysicsStep();
        }
    }
}
