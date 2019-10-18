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
        private GameObject _countdownTextGameObject;
        private Text _countdownText;

        [Range(0,MaxTimerSeconds)]
        private int _seconds;

        // Start is called before the first frame update
        void Start()
        {
            _countdownText = _countdownTextGameObject.GetComponent<Text>();
        }

        public void StartCountDown(int seconds)
        {
            StartCoroutine(CountdownRoutine(seconds));
        }

        private IEnumerator CountdownRoutine(int seconds)
        {
            _seconds = Math.Min(seconds, MaxTimerSeconds);
            while(_seconds > 0)
            {
                yield return new WaitForSeconds(1.0f);
                _seconds--;
            }

            // Race starts
            _countdownTextGameObject.gameObject.SetActive(false);
        }
    }
}