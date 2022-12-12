using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangeState : State
{
    [SerializeField] ShootController shootController;
    [SerializeField] GetAwayFlyState getAwayFlyState;
    public override State RunCurrentState()
    {
        shootController.Shoot();
        return getAwayFlyState;
    }
}
