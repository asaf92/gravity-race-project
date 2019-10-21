using Game.Race;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
    [RequireComponent(typeof(AudioSource))]
    public class RaceStartCountdownComp : MonoBehaviour, IRaceStartCountdownComp
    {
        private const int MaxTimerSeconds = 5;

        [SerializeField] private AudioClip _countdownSound;
        [SerializeField] private AudioClip _raceStartSound;
        [SerializeField] private GameObject _raceManagerComp;
        [SerializeField] private GameObject _countdownTextGameObject;

        [Range(0,MaxTimerSeconds)]
        private int _seconds;

        private Text _countdownText;
        private IRaceManager _raceManager;
        private AudioSource _audioSource;
        private RaceStartCountdownController _controller;

        void Start()
        {
            _raceManager = _raceManagerComp.GetComponent<IRaceManagerComp>().RaceManager;
            _controller = new RaceStartCountdownController(this, _raceManager);
            _countdownText = _countdownTextGameObject.GetComponent<Text>();
            _audioSource = GetComponent<AudioSource>();
        }

        public void SetCountdownDisplay(string displayText)
        {
            Debug.Log($"Setting countdown display to {displayText}");
            _countdownText.text = displayText;
        }

        public void RemoveCountdownDisplay(float delay)
        {
            StartCoroutine(RemoveComponent(delay));
        }

        public void PlayCountdownSound()
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_countdownSound);
            }
        }

        public void PlayRaceStartSound()
        {
            if (!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(_raceStartSound);
            }
        }

        /// <summary>
        /// Removes the component's GameObject
        /// </summary>
        /// <param name="delay">The delay in seconds</param>
        /// <returns></returns>
        private IEnumerator RemoveComponent(float delay)
        {
            yield return null;
            yield return new WaitForSeconds(delay);
            Destroy(_countdownTextGameObject);
        }
    }
}