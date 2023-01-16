using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloudDetector : MonoBehaviour
{
    [SerializeField] UnityEvent dieEvent;

    private void OnCollisionEnter(Collision collision)
    {
        dieEvent.Invoke();
    }
}
