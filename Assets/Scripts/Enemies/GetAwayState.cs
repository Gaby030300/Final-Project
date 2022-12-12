using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAwayState : State
{
    public Transform player;
    public Rigidbody rbParent;
    public IdleState idleState;
    public bool canBack;
    public override State RunCurrentState()
    {
        //rbParent.transform.LookAt(player);
        rbParent.AddRelativeForce(Vector3.back * 2, ForceMode.Impulse);
        //rbParent.AddForce(Vector3.back * 2, ForceMode.Impulse);
        float distance = Vector3.Distance(rbParent.position, player.position);
        //if (distance > 10)
        //{
        //}
        //return this;
        return idleState;

    }
}
