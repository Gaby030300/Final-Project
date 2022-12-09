using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChaseState : State
{
    public bool isInAttackRange, isInRetreatRange, isInChaseRange;
    public Attackstate attackstate;
    public IdleState idleState;
    public Rigidbody rbParent;
    public Transform player;
    public GetAwayState getAwayState;
    public override State RunCurrentState()
    {
        Debug.Log("Chasing Player");
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, 4 * Time.deltaTime);
        rbParent.MovePosition(pos);
        rbParent.transform.LookAt(player);
        float distance=Vector3.Distance(rbParent.position, player.position);
        Debug.Log(distance);
        if (distance > 10)
        {
            return idleState;
        }
        else if (distance < 2)
        {
            Debug.Log("I Attack");
            return attackstate;
        }
        return this;
    }
}
