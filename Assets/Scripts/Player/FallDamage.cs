using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallDamage : MonoBehaviour
{
    public float minimumFall;

    [SerializeField] bool grounded = false;
    Rigidbody rb;
    [SerializeField] bool wasGrounded;
    [SerializeField] bool wasFalling;
    float startOfFall;
    PlayerHealth health;

    private void Start()
    {
        health = GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CheckGround();

        if (!wasFalling && isFalling) startOfFall = transform.position.y;
        if (!wasGrounded && grounded) TakeDamage();

        wasGrounded = grounded;
        wasFalling = isFalling;
    }



    public void CheckGround()
    {
        grounded = Physics.Raycast(transform.position,-Vector3.up, 0.5f);
    }

    //IEnumerator Shake(float duration)
    //{

    //}
    bool isFalling { get { return (!grounded && rb.velocity.y < 0); } }

    public void TakeDamage()
    {
        float fallDistance = startOfFall - transform.position.y;
        if (fallDistance > minimumFall)
        {
            health.RestHealt((int) fallDistance);
        }
    }

}
