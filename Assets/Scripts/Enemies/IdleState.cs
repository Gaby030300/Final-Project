using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IdleState : State
{
    public bool canSeeThePlayer;
    public State chaseState;
    [SerializeField] StateManager stateManager;

    public override State RunCurrentState()
    {
        stateManager.StopMoving();
        if (canSeeThePlayer)
        {
            stateManager.StartToMove();
            return chaseState;
        }
        else
        {
            return this;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            canSeeThePlayer = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
            canSeeThePlayer = false;
    }
}
