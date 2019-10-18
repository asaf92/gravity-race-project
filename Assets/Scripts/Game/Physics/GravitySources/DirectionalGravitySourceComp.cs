using UnityEngine;

namespace Game.Physics.GravitySources
{
    public class DirectionalGravitySourceComp : MonoBehaviour, IDirectionalGravitySourceComponent
    {
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
        /// The direction that the subjects will be pulled to (magnitude is irrelevant)
        /// </summary>
        public Vector3 GravityPullDirection => transform.TransformDirection(_direction);
        [SerializeField] private Vector3 _direction;

        /// <summary>
        /// Radius from which the gravity source does not affect objects
        /// </summary>
        public float Radius => _radius;

        public Vector3 SurfaceNormal => transform.up;

        [SerializeField] private float _radius;

        /// <summary>
        /// A reference to the controller used to control this humble-object
        /// </summary>
        private IGravitySourceController _controller;

        /// <summary>
        /// The game object that holds the <see cref="IAreaOfEffect{T}"/> component
        /// </summary>
        [SerializeField] private GameObject _areaOfEffectTrigger;

        /// <summary>
        /// Reference to the area of effect component 
        /// </summary>
        private IAreaOfEffect<IGravitySubjectController> _gravityAreaTrigger;

        // Start is called before the first frame update
        void Start()
        {
            _gravityAreaTrigger = _areaOfEffectTrigger.GetComponent<IAreaOfEffect<IGravitySubjectController>>();
            _controller = new DirectionalGravitySourceController(this, _gravityAreaTrigger);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            _controller.PhysicsStep();
        }
    }
}