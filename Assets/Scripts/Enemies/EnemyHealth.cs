using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHealt;
    [SerializeField] int maxHealt;
    [SerializeField] Collider capsuleCollider;
    Animator anim;
    public bool isAlive, canBeHurt;

    private void Start()
    {
        isAlive = true;
        canBeHurt = true;
        anim = GetComponent<Animator>();
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        if (currentHealt > 0 && canBeHurt)
        {
            StartCoroutine(AnimationDamage(healtToLoss));
        }
        else
        {            
            if (currentHealt <= 0)
                EnemyDie();
        }
    }

    IEnumerator AnimationDamage(int healToloss)
    {
        SoundManager.instance.PlaySFX("Zombie Hurt");
        currentHealt -= healToloss;
        anim.SetBool("TakingDamage", true);
        yield return new WaitForSeconds(1f);
        canBeHurt = true;
        anim.SetBool("TakingDamage", false);
    }

    public void EnemyDie()
    {
        isAlive = false;
        capsuleCollider.enabled = false;
        SoundManager.instance.PlaySFX("Zombie Die");
        anim.SetTrigger("Die");
        Invoke("TurnOffSound",1f);
        //gameObject.SetActive(false);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ball") && canBeHurt)
    //    {
    //        Debug.Log("Herido");
    //        RestHealt(5);
    //        canBeHurt = false;
    //    }
    //}
}
