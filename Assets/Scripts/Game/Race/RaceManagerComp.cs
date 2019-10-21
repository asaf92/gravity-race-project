using Game.Constants;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Vehicles.Car;

namespace Game.Race
{
    /// <summary>
    /// The race manager component on the race manager <see cref="GameObject"/>
    /// </summary>
    public class RaceManagerComp : MonoBehaviour, IRaceManagerComp
    {
        private const float ExitLevelDelay = 5.5f;

        /// <summary>
        /// A reference to the Race Manager object
        /// </summary>
        public IRaceManager RaceManager { get; private set; }

        /// <summary>
        /// The <see cref="GameObject"/> that holds the finish trigger
        /// </summary>
        [SerializeField] private GameObject _finishTriggerGameObject;

        [SerializeField] private int _raceStartCountdownTime;
        [SerializeField] private int _numberOfLaps;
        [SerializeField] private int _numberOfPlayers;
        private GameObject _playerGameObject;
        private IFinishTriggerController _finishTriggerController;
        private CarController _carController;
        private CarUserControl _carUserControl;

        /// <summary>
        /// Raised every frame update
        /// </summary>
        public event EventHandler<RaceTimeUpdateEventArgs> RaceTimeUpdate;

        void Awake()
        {
            _playerGameObject = GameObject.FindGameObjectWithTag(Tags.Player);
            RaceManager = new RaceManager(_numberOfLaps, _numberOfPlayers, this, _raceStartCountdownTime);
        }

        void Start()
        {
            _carController = _playerGameObject.GetComponent<CarController>();
            _carUserControl = _playerGameObject.GetComponent<CarUserControl>();
            _carUserControl.enabled = false;
            _finishTriggerController = _finishTriggerGameObject.GetComponent<FinishTriggerComp>().Controller
                ?? GameObject.FindGameObjectWithTag(Tags.FinishTrigger).GetComponent<FinishTriggerComp>().Controller
                ?? throw new ArgumentException("Finish trigger not found");
            RaceManager.InitFinishTrigger(_finishTriggerController);
        }

        void Update()
        {
            RaceTimeUpdate?.Invoke(this, new RaceTimeUpdateEventArgs(Time.deltaTime));
        }

        public void AllowUserControl(bool allow = true)
        {
            if (allow)
            {
                _carUserControl.enabled = true;
                return;
            }

            _carUserControl.MaxBrake();
        }

        public void EndLevel()
        {
            StartCoroutine(nameof(EndLevelCoroutine));
        }

        private IEnumerator EndLevelCoroutine()
        {
            yield return new WaitForSeconds(ExitLevelDelay);
            Debug.Log("Exiting Scene");
            SceneManager.LoadScene("MainMenu");
        }
    }
}