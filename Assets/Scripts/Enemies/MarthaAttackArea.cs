using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarthaAttackArea : MonoBehaviour
{
    [SerializeField] BasicEnemyController basicEnemyController;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] PlayerHealth player;
    [SerializeField] int damage;
    public bool canAttack;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && enemyHealth.isAlive)
        {
            canAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = false;
        }
    }

    public void MakeDamage()
    {
        SoundManager.instance.PlaySFX("Damage Martha");
        if (canAttack)
        {
            player.RestHealt(damage);
        }
    }
}
