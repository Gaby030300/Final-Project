using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChaseState : State
{
    public Attackstate attackstate;
    public Rigidbody rbParent;
    public Transform player;
    public float speed;
    public override State RunCurrentState()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        rbParent.MovePosition(pos);
        rbParent.transform.LookAt(player);
        float distance=Vector3.Distance(rbParent.position, player.position);
        if (distance < 2)
        {
            return attackstate;
        }
        return this;
    }
}
