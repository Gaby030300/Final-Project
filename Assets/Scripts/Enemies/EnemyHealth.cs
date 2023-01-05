using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHealt;
    [SerializeField] int maxHealt;
    [SerializeField] CapsuleCollider capsuleCollider;
    Animator anim;
    public bool isAlive;
    private void Start()
    {
        isAlive = true;
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        if (currentHealt>0)
        {
            currentHealt -= healtToLoss;
            if (currentHealt <= 0)
                EnemyDie();
        }
    }

    public void EnemyDie()
    {
        isAlive = false;
        capsuleCollider.enabled = false;
        anim.SetTrigger("Die");
        //gameObject.SetActive(false);
    }
}
