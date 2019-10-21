using Game.Race;
using Presentation.UI.Constants;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
    internal class FinishTimeComp : MonoBehaviour, IFinishTimeComp
    {
        [SerializeField] private GameObject _raceFinishTimeTextGameObject;
        private Text _raceFinishTimeText;

        [SerializeField] private GameObject _raceManagerObject;
        private IRaceManager _raceManager;

        private FinishTimeController _controller;

        void Start()
        {
            _raceManager = _raceManagerObject.GetComponent<IRaceManagerComp>().RaceManager;
            _controller = new FinishTimeController(this, _raceManager);
            _raceFinishTimeText = _raceFinishTimeTextGameObject.GetComponent<Text>();
            _raceFinishTimeText.enabled = false;
        }

        public void ShowFinishTime(TimeSpan finishTime, bool newRecord = false)
        {
            var finishTimeDisplayText = finishTime.ToString(HudMessages.TimeStringFormat);
            if (newRecord)
            {
                finishTimeDisplayText += $"{Environment.NewLine}{HudMessages.NewRecordString}";
            }

            _raceFinishTimeText.text = finishTimeDisplayText;
            _raceFinishTimeText.enabled = true;
        }
    }
}
