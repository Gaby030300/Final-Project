using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallDamage : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speedToHurt;
    [SerializeField] UnityEvent playerDie;
    [SerializeField] CapsuleCollider collider;
    [SerializeField] float speedBeforeLanding;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public bool IsGround()
    {
        RaycastHit[] hit;
        hit = Physics.CapsuleCastAll(collider.bounds.center, collider.bounds.size, 0, Vector3.down, .1f);
        return hit!=null;

    }

    private void Update()
    {
        if (!IsGround())
        {
            speedBeforeLanding = rb.velocity.y;
        }
        else
        {
            if (speedBeforeLanding < speedToHurt)
            {

                playerDie.Invoke();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(rb.velocity.y);
        Debug.Log("Colision");
        if (rb.velocity.y < speedToHurt)
        {
            Debug.Log("Colision dura");

        }
    }
}
