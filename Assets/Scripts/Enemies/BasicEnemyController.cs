using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BasicEnemyController : MonoBehaviour
{
    public Transform target;
    public float speed;
    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);
    }
}
