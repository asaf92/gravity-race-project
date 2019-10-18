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
        Debug.Log($"AOE collider awake");
        _gravitySubjects = new List<IGravitySubjectController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var gravitySubject = GetGravitySubject(other);
        Debug.Log($"OnTriggerEnter found {gravitySubject}");
        if (gravitySubject != null && !_gravitySubjects.Contains(gravitySubject.Controller))
        {
            Debug.Log("Gravity subject component found");
            _gravitySubjects.Add(gravitySubject.Controller);
            return;
        }

        //Debug.Log($"{other.gameObject.name} has no gravity subject component");
    }

    private void OnTriggerExit(Collider other)
    {
        var gravitySubject = GetGravitySubject(other);
        Debug.Log($"OnTriggerExit ran on {gravitySubject}");
        _gravitySubjects.Remove(gravitySubject.Controller);
    }

    private static IGravitySubjectComp GetGravitySubject(Collider other)
    {
        return other.attachedRigidbody.gameObject.GetComponent<IGravitySubjectComp>();
    }

}
