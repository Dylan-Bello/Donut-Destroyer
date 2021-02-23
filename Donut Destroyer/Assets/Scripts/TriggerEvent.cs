using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent unityEvent;


    private void OnTriggerEnter2D(Collider2D other)
    {
        unityEvent.Invoke();
    }


    /*private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            unityEvent.Invoke();
        }
    }*/
}
