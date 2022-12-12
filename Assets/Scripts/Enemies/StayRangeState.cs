using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayRangeState : State
{
    [SerializeField] Transform player;
    [SerializeField] Rigidbody rbParent;
    [SerializeField] GetAwayFlyState getAwayState;
    [SerializeField] AttackRangeState attackRangeState;
    [SerializeField] IdleFlyState idleFlyState;
    [SerializeField] ShootController shootController;
    [SerializeField] float speed;
    public override State RunCurrentState()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        rbParent.MovePosition(pos);
        rbParent.transform.LookAt(player);
        float distance = Vector3.Distance(rbParent.position, player.position);
        if (shootController.CanShoot())
        {
            shootController.Shoot();
        }
        if (rbParent.position.y > 7)
        {
            rbParent.velocity = Vector3.zero;
            return idleFlyState;
        }
        if(distance < 10)
        {
            return getAwayState;
        }
        //if (distance < 10)
        //{
        //    return attackRangeState;
        //}
        return this;
    }
}
