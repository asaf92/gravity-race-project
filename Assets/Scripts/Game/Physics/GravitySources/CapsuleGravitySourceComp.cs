using UnityEngine;

namespace Game.Physics.GravitySources
{
    public class CapsuleGravitySourceComp : MonoBehaviour, ICapsuleGravitySourceComponent
    {
        /// <summary>
        /// The direction of the local Y axis of the capsule
        /// </summary>
        public Vector3 ForwardDirection => transform.up;
        
        /// <summary>
        /// The power of the gravity in m/s^2
        /// </summary>
        public float Strength => _strength;
        [SerializeField] private float _strength = 0f;

        /// <summary>
        /// The world-space position of the object
        /// </summary>
        public Vector3 Position => transform.position;

        private IGravitySourceController _controller;
        [SerializeField] private GameObject _areaOfEffectGameObject;
        private IAreaOfEffect<IGravitySubjectController> _areaOfEffect;

        void Awake()
        {
            _areaOfEffect = _areaOfEffectGameObject.GetComponent<IAreaOfEffect<IGravitySubjectController>>();
            _controller = new CapsuleGravitySourceController(this, _areaOfEffect);
        }

        void FixedUpdate()
        {
            _controller.PhysicsStep();
        }
    }
}
