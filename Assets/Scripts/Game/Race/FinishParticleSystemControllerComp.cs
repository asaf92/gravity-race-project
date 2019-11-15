using System;
using UnityEngine;


namespace Game.Race
{
    [RequireComponent(typeof(ParticleSystem))]
    public class FinishParticleSystemControllerComp : MonoBehaviour
    {
        private const int particlesLifetime = 3;
        private const int particlesSize = 1;

        [SerializeField] private FinishTriggerComp _finishTriggerComp;
        [SerializeField] private RaceManagerComp _raceManagerComp;

        private ParticleSystem _particleSystem;
        private IFinishTriggerController _finishTrigger;
        private IRaceManager _raceManager;

        void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            _finishTrigger = _finishTriggerComp?.Controller ?? throw new ArgumentNullException(nameof(_finishTriggerComp));
            _raceManager = _raceManagerComp?.RaceManager ?? throw new ArgumentNullException(nameof(_finishTriggerComp));

            _finishTrigger.RaceFinished += _finishTrigger_RaceFinished;
            _raceManager.RaceStarted += _raceManager_RaceStarted;
        }

        private void _raceManager_RaceStarted(object sender, Events.RaceStartedEventArgs e)
        {
            var settings = _particleSystem.main;
            settings.startLifetime = particlesLifetime;
            settings.startSize = particlesSize;
        }

        private void _finishTrigger_RaceFinished(object sender, Events.FinishTriggerActivated e)
        {
            var particleSettings = _particleSystem.main;
            particleSettings.startColor = new ParticleSystem.MinMaxGradient(Color.blue);
        }
    }
}