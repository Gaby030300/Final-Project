using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMelee : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(other.GetComponent<EnemyHealth>() != null)
            {
                other.GetComponent<EnemyHealth>().RestHealt(5);
            }else if (other.GetComponent<ZombieHealth>() !=null)
            {
                other.GetComponent<ZombieHealth>().TakeMeleeDamage();
            }
        }
    }

}
