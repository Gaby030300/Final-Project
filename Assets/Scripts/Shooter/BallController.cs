using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float activeTime;
    private float shootTime;
    [SerializeField] int damage;
    [SerializeField] bool enemyBullet;
    [SerializeField] ParticleSystem hitParticle;

    private void OnEnable()
    {
        shootTime = Time.time;
    }
    private void Update()
    {
        if (Time.time - shootTime >= activeTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (enemyBullet)
        //{
        //    if (other.CompareTag("Player"))
        //    {
        //        //hitParticle.Play();
        //        //other.gameObject.GetComponent<PlayerHealth>()?.RestHealt(damage);
        //        gameObject.SetActive(false);
        //    }
        //}
        //else
        //{
        //    if (other.CompareTag("Enemy"))
        //    {
        //        //hitParticle.Play();
        //        //other.gameObject.GetComponent<EnemyHealth>()?.RestHealt(damage);
        //        gameObject.SetActive(false);
        //    }
        //}
        if (!other.CompareTag("Activator"))
        {
            //hitParticle.Play();
            gameObject.SetActive(false);
        }
    }
}
