using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayRangeState : State
{
    [SerializeField] Transform pointToShoot,player;
    [SerializeField] ShootController shootController;
    [SerializeField] Rigidbody rbParent;
    [SerializeField] StateManager stateManager;
    [SerializeField] GetAwayFlyState getAwayState;
    bool haveToRetreat;
    public override State RunCurrentState()
    {
        rbParent.velocity = Vector3.zero;
        if (haveToRetreat)
        {
            return getAwayState;
        }
        else
        {
            pointToShoot.LookAt(player);
            if (shootController.CanShoot())
            {
                shootController.Shoot();
            }
        }
        return this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            haveToRetreat = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            haveToRetreat = false;
        }        
    }
}
