using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    PlayerController player;
    private ShootController shoot;
    private bool canShoot;

    private void Awake()
    {
        canShoot = true;
        shoot = GetComponent<ShootController>();
        player = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (player.canMove)
            Shooting();
    }


    public void Shooting()
    {
        if (Input.GetButton("Fire1") && canShoot)
        {
            if (shoot.CanShoot())
            {
                shoot.Shoot();
            }
        }
    }
}
