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
        StartCoroutine(ChangeState());
        if (canSeeThePlayer)
        {
            StopAllCoroutines();
            stateManager.StartToMove();
            canSeeThePlayer = false;
            return chaseState;
        }
        else
        {
            return this;
        }
    }

    IEnumerator ChangeState()
    {
        yield return new WaitForSeconds(2);
        canSeeThePlayer = true;
    }
}
