using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] float timeToDash;
    PlayerController player;
    Rigidbody rb;

    private bool isDashing = true;
    [SerializeField] private float dashVelocity = 10.0f;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (player.canMove)
            Dash();
        //if (Input.GetKeyDown(KeyCode.Space) && isDashing)
        //{
        //    rb.AddForce(transform.forward * dashVelocity, ForceMode.Impulse);
        //    isDashing = false;
        //    StartCoroutine(DashTime());
        //}
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isDashing)
        {
            rb.AddForce(transform.forward * dashVelocity, ForceMode.Impulse);
            isDashing = false;
            StartCoroutine(DashTime());
        }
    }

    IEnumerator DashTime()
    {
        player.DeactivateLaser();
        player.animPlayer.SetBool("Rolling", true);
        yield return new WaitForSeconds(timeToDash);
        isDashing = true;
        player.animPlayer.SetBool("Rolling", false);
        player.ActivateLaser();
        yield return new WaitForSeconds(0.1f);
        rb.velocity = Vector3.zero;
    }
}
