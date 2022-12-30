using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttackArea : MonoBehaviour
{
    [SerializeField] BasicEnemyController basicEnemyController;
    public bool canAttack;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = true;
            basicEnemyController.StartAttack();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canAttack = false;
            basicEnemyController.StopAttack();            
        }
    }
}
