using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAwayFlyState : State
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody rbParent;
    [SerializeField] IdleFlyState idleFlyState;
    [SerializeField] StateManager stateManager;
    public override State RunCurrentState()
    {
        stateManager.StopMoving();
        rbParent.AddRelativeForce(Vector3.back * 28, ForceMode.Impulse);
        return idleFlyState;
    }
}
