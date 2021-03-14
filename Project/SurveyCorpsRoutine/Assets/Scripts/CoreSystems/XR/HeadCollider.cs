using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider), typeof(Rigidbody))]
public class HeadCollider : MonoBehaviour
{
    [SerializeField] RealWorldStatusSO _realWorldStatus;
    Collider triggerCollider;
    public void Awake()
    {
        triggerCollider = GetComponent<Collider>();
        triggerCollider.isTrigger = true;
    }
    public RealWorldStatusSO realWorldStatus
    {
        get => _realWorldStatus;
        set => _realWorldStatus = value;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name + " on enter");
    }
    public void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.name + " on exit");
    }
}
