using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float activeTime;
    private float shootTime;

    private void OnEnable()
    {
        shootTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - shootTime >= activeTime)
        {
            gameObject.SetActive(false);
        }
    }
}
