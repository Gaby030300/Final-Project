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
        StartCoroutine(ChangeState());
        if (canSeeThePlayer)
        {
            StopAllCoroutines();
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
