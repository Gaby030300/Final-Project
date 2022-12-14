using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ChaseState : State
{
    public Attackstate attackstate;
    bool canAttack;
    public override State RunCurrentState()
    {
        if (canAttack)
        {
            return attackstate;
        }
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            canAttack = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            canAttack = false;
    }
}
