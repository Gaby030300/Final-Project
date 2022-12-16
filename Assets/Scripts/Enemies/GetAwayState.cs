using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAwayState : State
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody rbParent;
    [SerializeField] IdleState idleState;
    [SerializeField] bool canBack;
    [SerializeField] StateManager stateManager;
    public override State RunCurrentState()
    {
        Debug.Log("Se retira");
        stateManager.StopMoving();
        rbParent.transform.LookAt(player);
        rbParent.AddRelativeForce(Vector3.back * 2, ForceMode.Impulse);
        return idleState;
    }
}
