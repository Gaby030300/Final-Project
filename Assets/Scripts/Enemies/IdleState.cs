using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public bool canSeeThePlayer;
    public ChaseState chaseState;
    public Rigidbody rbParent;

    public override State RunCurrentState()
    {
        rbParent.velocity = Vector3.zero;
        if (canSeeThePlayer)
        {
            return chaseState;
        }
        else
        {
            Debug.Log("Not Chased yet");
            return this;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canSeeThePlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canSeeThePlayer = false;        
    }
}
