using Game.Physics;
using System.Collections.Generic;
using UnityEngine;

public class AoeColliderComp : MonoBehaviour, IAreaOfEffect<IGravitySubjectController>
{
    /// <summary>
    /// All the gravity subjects that are inside the AOE collider boundries
    /// </summary>
    public IEnumerable<IGravitySubjectController> ObjectsInTrigger => _gravitySubjects;
    private IList<IGravitySubjectController> _gravitySubjects;

    private void Awake()
    {
        _gravitySubjects = new List<IGravitySubjectController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var gravitySubject = GetGravitySubject(other);
        if (gravitySubject != null && !_gravitySubjects.Contains(gravitySubject.Controller))
        {
            _gravitySubjects.Add(gravitySubject.Controller);
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var gravitySubject = GetGravitySubject(other);
        _gravitySubjects.Remove(gravitySubject.Controller);
    }

    private static IGravitySubjectComp GetGravitySubject(Collider other)
    {
        return other.attachedRigidbody.gameObject.GetComponent<IGravitySubjectComp>();
    }

}
