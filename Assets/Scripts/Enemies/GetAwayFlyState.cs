using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAwayFlyState : State
{
    [SerializeField] Rigidbody rbParent;
    [SerializeField] StayRangeState stayRange;
    public override State RunCurrentState()
    {
        
        rbParent.AddRelativeForce((Vector3.back*14 + Vector3.up*8).normalized , ForceMode.Impulse);
        return stayRange;
    }
}
