using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activator : MonoBehaviour
{
    [SerializeField] UnityEvent activateEvent;

    public void ActivateEvent()
    {
        activateEvent.Invoke();
    }

}
