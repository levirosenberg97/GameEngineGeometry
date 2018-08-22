using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public TriggerEvent OnTriggerEnterEvent;

    public CollisionEvent OnCollisionEnterEvent;


    private void OnCollisionEnter(Collision collision)
    {
        if(OnCollisionEnterEvent != null)
        {
            OnCollisionEnterEvent.Invoke(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(OnTriggerEnterEvent != null)
        {
            OnTriggerEnterEvent.Invoke(other);
        }
    }
}

[System.Serializable]
public class TriggerEvent : UnityEvent<Collider>
{

}

[System.Serializable]
public class CollisionEvent : UnityEvent<Collision>
{

}