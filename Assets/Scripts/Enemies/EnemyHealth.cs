using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHealt;
    [SerializeField] int maxHealt;
    [SerializeField] Collider capsuleCollider;
    Animator anim;
    public bool isAlive;

    [SerializeField] AudioClip soundHurt, soundDie;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isAlive = true;
        anim = GetComponent<Animator>();
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        if (currentHealt > 0)
        {
            StartCoroutine(AnimationDamage());
            audioSource.PlayOneShot(soundHurt);
            currentHealt -= healtToLoss;
        }
        else
        {
            if (currentHealt <= 0)
                EnemyDie();
        }
    }

    IEnumerator AnimationDamage()
    {
        anim.SetBool("TakingDamage", true);
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("TakingDamage", false);
    }

    public void EnemyDie()
    {
        isAlive = false;
        capsuleCollider.enabled = false;
        audioSource.PlayOneShot(soundDie);
        anim.SetTrigger("Die");
        Invoke("TurnOffSound",1f);
        //gameObject.SetActive(false);
    }

    public void TurnOffSound()
    {
        audioSource.volume = 0f;
    }
}
