using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CloudDetector : MonoBehaviour
{
    [SerializeField] UnityEvent dieEvent;

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        dieEvent.Invoke();
    //        PlaySound1();
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dieEvent.Invoke();
            PlaySound1();
        }
    }

    public void PlaySound1()
    {
        SoundManager.instance.PlaySFX("Big Monster");
    }
}
