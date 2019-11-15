using System;
using System.Collections.Generic;
using Game.Physics;
using UnityEngine;

namespace Game.Race
{
    public class FinishTriggerComp : MonoBehaviour, IAreaOfEffect<IGravitySubjectController>
    {
        public IEnumerable<IGravitySubjectController> ObjectsInTrigger { get; private set; }

        public IFinishTriggerController Controller;

        private void Awake()
        {
            Controller = new FinishTriggerController();
        }

        private void OnTriggerEnter(Collider other)
        {
            var gravitySubject = other.attachedRigidbody.gameObject.GetComponent<IGravitySubjectComp>().Controller;
            if (gravitySubject == null) return;

            Controller.VehicleFinishedRace(gravitySubject);
        }
    }
}