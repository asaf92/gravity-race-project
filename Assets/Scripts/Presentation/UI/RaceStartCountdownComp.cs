using Game.Race;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
    public class RaceStartCountdownComp : MonoBehaviour, IRaceStartCountdownComp
    {
        private const int MaxTimerSeconds = 5;

        [SerializeField]
        private GameObject _raceManagerComp;
        private IRaceManager _raceManager;

        [SerializeField]
        private GameObject _countdownTextGameObject;
        private Text _countdownText;

        [Range(0,MaxTimerSeconds)]
        private int _seconds;

        private RaceStartCountdownController _controller;

        public void SetCountdownDisplay(string displayText)
        {
            _countdownText.text = displayText;
        }

        void Start()
        {
            _raceManager = _raceManagerComp.GetComponent<IRaceManagerComp>().RaceManager;
            _controller = new RaceStartCountdownController(this, _raceManager);
            _countdownText = _countdownTextGameObject.GetComponent<Text>();
        }

        public void RemoveCountdownDisplay(float delay)
        {
            Debug.Log("Removing countdown text");
            StartCoroutine(RemoveComponent(delay));
        }

        /// <summary>
        /// Removes the component's GameObject
        /// </summary>
        /// <param name="delay">The delay in seconds</param>
        /// <returns></returns>
        private IEnumerator RemoveComponent(float delay)
        {
            Debug.Log("Remove component called");
            yield return new WaitForSeconds(delay);
            Debug.Log("Remove component finished waiting");
            Destroy(_countdownTextGameObject, delay);
            Debug.Log("Remove component finished executing");
        }
    }
}