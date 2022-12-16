using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attackstate : State
{
    [SerializeField] Transform player;
    [SerializeField] IdleState idleState;
    [SerializeField] StateManager stateManager;
    [SerializeField] float forceToPush;
    public override State RunCurrentState()
    {
        stateManager.StopMoving();
        player.GetComponent<PlayerHealth>()?.RestHealt(5);
        Attack();
        return idleState;
    }

    public void Attack()
    {
        player.GetComponent<Rigidbody>().AddForce(transform.forward * forceToPush, ForceMode.Impulse);
    }
}
