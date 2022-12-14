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
        StartCoroutine(ChangeState());
        if (canSeeThePlayer)
        {
            StopAllCoroutines();
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

    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(1);
        canSeeThePlayer = true;
    }
}
