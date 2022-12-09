using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackstate : State
{
    public bool takingDamage;
    public Rigidbody rbParent;
    public Transform player;
    public GetAwayState getAway;
    public ChaseState chaseState;
    public override State RunCurrentState()
    {
        rbParent.transform.LookAt(player);
        float distance = Vector3.Distance(rbParent.position, player.position);
        if (distance > 4)
        {
            return chaseState;
        }
        if (takingDamage)
        {
            takingDamage = false;
            return getAway;
        }
        return this;
    }
}
