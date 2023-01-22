using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackMelee : MonoBehaviour
{
    PlayerController player;

    [SerializeField] float timeToAttackMelee;
    [SerializeField] GameObject AttackMelee;

    public bool canAttackMelee;

    private void Awake()
    {
        canAttackMelee = true;
        player = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (player.canMove)
            AttakingMelee();
    }

    public void AttakingMelee()
    {
        if (Input.GetButtonDown("Fire2") && canAttackMelee)
        {
            StartCoroutine(StopAttackingMelee());
        }
    }

    IEnumerator StopAttackingMelee()
    {
        player.DeactivateLaser();
        canAttackMelee = false;
        player.animPlayer.SetBool("Attacking", true);
        AttackMelee.SetActive(true);
        yield return new WaitForSeconds(timeToAttackMelee);
        AttackMelee.SetActive(false);
        player.animPlayer.SetBool("Attacking", false);
        canAttackMelee = true;
        player.ActivateLaser();
    }
}
