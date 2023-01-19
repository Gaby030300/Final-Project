using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] List<Collider> listCollider;
    [SerializeField] List<MonoBehaviour> listToDesactivate;
    Animator anim;
    public bool isAlive, isTakingDamage;

    [SerializeField] AudioClip soundDie;
    AudioSource audioSource;

    [SerializeField]private Rigidbody[] rigidbodies;
    [SerializeField] List<Collider> colliders;

    [SerializeField] int hitsToDie;
    public int hitsMelee;

    private void Start()
    {
        hitsMelee = 0;
        rigidbodies = transform.GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        SetEnabled(false);
        isAlive = true;
    }

    void SetEnabled(bool enabled)
    {
        bool isKinematic = !enabled;
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = isKinematic;
        }
        foreach (Collider collider in colliders)
        {
            collider.enabled = enabled;
        }

        anim.enabled = !enabled;
    }
    public void EnemyDie()
    {
        SetEnabled(true);
        isAlive = false;
        SoundManager.instance.PlaySFX("Zombie Die");
        anim.SetTrigger("Die");
        foreach (Collider i in listCollider)
        {
            i.enabled = false;
        }
        foreach (MonoBehaviour i in listToDesactivate)
        {
            i.enabled = false;
        }
        Invoke("TurnOffSound", 1f);
    }

    public void TurnOffSound()
    {
        audioSource.volume = 0f;
    }

    public void TakeMeleeDamage()
    {
        if (!isTakingDamage)
        {
            hitsMelee++;
            isTakingDamage = true;
            if (hitsMelee >= hitsToDie)
            {
                EnemyDie();
            }
            else
            {
                StartCoroutine(StopTakingDamage());
            }
        }
    }

    IEnumerator StopTakingDamage()
    {
        anim.SetBool("TakingDamage",true);
        yield return new WaitForSeconds(1);
        anim.SetBool("TakingDamage",false);
        isTakingDamage = false;
    }
}
