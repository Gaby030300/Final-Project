using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] Collider capsuleCollider;
    [SerializeField] List<MonoBehaviour> listToDesactivate;
    Animator anim;
    public bool isAlive;

    [SerializeField] AudioClip soundDie;
    AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isAlive = true;
        anim = GetComponent<Animator>();
    }
    public void EnemyDie()
    {
        isAlive = false;
        capsuleCollider.enabled = false;
        audioSource.PlayOneShot(soundDie);
        anim.SetTrigger("Die");
        foreach (MonoBehaviour i in listToDesactivate)
        {
            i.enabled = false;
        }
        Invoke("TurnOffSound", 1f);
        //gameObject.SetActive(false);
    }

    public void TurnOffSound()
    {
        audioSource.volume = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball") && isAlive)
        {
            EnemyDie();
            anim.SetTrigger("Die");
            isAlive = false;
        }
    }
}
