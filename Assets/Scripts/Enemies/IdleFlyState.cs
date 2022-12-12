using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleFlyState : State
{
    [SerializeField] Rigidbody rbParent;
    [SerializeField] StayRangeState stayRange;
    public override State RunCurrentState()
    {
        rbParent.AddForce(Vector3.down, ForceMode.Impulse);
        if (rbParent.position.y <= 1.8)
        {
            return stayRange;
        }
        return this;
    }
}
