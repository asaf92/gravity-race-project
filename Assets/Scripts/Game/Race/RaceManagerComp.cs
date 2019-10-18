using System;
using UnityEngine;

namespace Game.Race
{
    /// <summary>
    /// The race manager component on the race manager <see cref="GameObject"/>
    /// </summary>
    public class RaceManagerComp : MonoBehaviour, IRaceManagerComp
    {
        /// <summary>
        /// A reference to the Race Manager object
        /// </summary>
        public IRaceManager RaceManager { get; private set; }

        [SerializeField]
        private int _numberOfLaps;

        [SerializeField]
        private int _numberOfPlayers;

        /// <summary>
        /// The <see cref="GameObject"/> that holds the finish trigger
        /// </summary>
        [SerializeField]
        private GameObject _finishTriggerGameObject;

        private IFinishTriggerController _finishTriggerController;
        
        /// <summary>
        /// Raised every frame update
        /// </summary>
        public event EventHandler<RaceTimeUpdateEventArgs> RaceTimeUpdate;

        void Awake()
        {
            RaceManager = new RaceManager(_numberOfLaps,
                _numberOfPlayers,
                this);
        }

        void Start()
        {
            _finishTriggerController = _finishTriggerGameObject.GetComponent<FinishTriggerComp>().Controller ?? throw new ArgumentException("Finish trigger not found");
            RaceManager.InitFinishTrigger(_finishTriggerController);
        }

        void Update()
        {
            RaceTimeUpdate?.Invoke(this, new RaceTimeUpdateEventArgs(Time.deltaTime));
        }
    }
}