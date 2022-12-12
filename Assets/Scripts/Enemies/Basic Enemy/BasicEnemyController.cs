using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class BasicEnemyController : MonoBehaviour
{
    public Transform target;
    public float speed;
    bool isAttacking;
    Rigidbody rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!isAttacking)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rig.MovePosition(pos);
            transform.LookAt(target);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        rig.velocity = Vector3.zero;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Attack());
            other.GetComponent<PlayerHealth>().RestHealt(5);
            other.GetComponent<Rigidbody>()?.AddForce(transform.forward * 8, ForceMode.Impulse);
        }
    }

    IEnumerator Attack()
    {
        rig.velocity = Vector3.zero;
        isAttacking = true;
        yield return new WaitForSeconds(2);
        isAttacking = false;
    }
}
