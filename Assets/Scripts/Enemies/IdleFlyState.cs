using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFlyState : State
{
    bool canSeeThePlayer;
    [SerializeField] Transform player;
    [SerializeField] StateManager stateManager;
    [SerializeField] StayRangeState stayRange;
    public override State RunCurrentState()
    {
        stateManager.StopMoving();
        if (canSeeThePlayer)
        {
            stateManager.ChangeDestination(player);
            stateManager.StartToMove();
            canSeeThePlayer = false;
            return stayRange;
        }
        else
        {
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
