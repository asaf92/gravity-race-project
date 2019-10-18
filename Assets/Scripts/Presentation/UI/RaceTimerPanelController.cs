using Game.Race;
using Game.Constants;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
    public class RaceTimerPanelController : MonoBehaviour
    {
        private const string TimeStringFormat = @"mm\:ss\.ff";
        [SerializeField]
        private GameObject _raceManagerGameObject;
        [SerializeField]
        private Text _raceTimerTimeText;
        private IRaceManager _raceManager;
        private TimeSpan _currentRaceTime;
        private TimeSpan _bestTime;

        void Start()
        {
            if(_raceManagerGameObject == null) throw new ArgumentNullException(nameof(_raceManagerGameObject));
            if(_raceTimerTimeText == null) throw new ArgumentNullException(nameof(_raceTimerTimeText));

            _raceManager = GetRaceManager();
            _currentRaceTime = TimeSpan.FromSeconds(0);
            _bestTime = TimeSpan.FromSeconds(PlayerPrefs.GetInt(SettingsKeys.BestLapTime));
            UpdateTimerText();
        }

        void Update()
        {
            _currentRaceTime = TimeSpan.FromSeconds(_raceManager.RaceTime);
            UpdateTimerText();
        }

        private IRaceManager GetRaceManager() => _raceManagerGameObject.GetComponent<IRaceManagerComp>().RaceManager ?? throw new ArgumentNullException("Race manager not found");
        private void UpdateTimerText() => _raceTimerTimeText.text = _currentRaceTime.ToString(TimeStringFormat) + Environment.NewLine + _bestTime.ToString(TimeStringFormat);
    }
}