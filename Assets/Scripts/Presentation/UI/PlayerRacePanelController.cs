using Game.Race;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI
{
    public class PlayerRacePanelController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _raceManagerGameObject;
        private IRaceManager _raceManager;
        [SerializeField]
        private Text _panelText;

        private void Start()
        {
            _raceManager = GetRaceManager();
        }

        public void Update()
        {
            if (_panelText == null)
            {
                Debug.Log($"{nameof(_panelText)} is null");
                throw new InvalidOperationException();
            }

            _panelText.text =
                $"Lap: {_raceManager.PlayerLap}/{_raceManager.NumberOfLaps}\n" +
                $"Position: {_raceManager.PlayerPosition}/{_raceManager.NumberOfPlayers}";
        }

        private IRaceManager GetRaceManager()
        {
            return _raceManagerGameObject.GetComponent<IRaceManagerComp>().RaceManager ?? throw new ArgumentNullException(nameof(IRaceManagerComp.RaceManager));
        }
    }
}