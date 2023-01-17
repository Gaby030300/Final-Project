using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    private ObjectPooling ballPool;
    public Transform outPoint;

    public int currentAmmunition;
    public int maxAmmunition;
    public bool unlimitedAmmunition;

    public float ballVelocity;
    public float shootFrecuency;
    private float lastTimeShoot;
    private bool isPlayer;

    [SerializeField] AudioClip soundEffect;
    AudioSource audioSource;

    [SerializeField] ParticleSystem muzzle;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (GetComponent<PlayerController>())
        {
            isPlayer = true;
        }
        ballPool = GetComponent<ObjectPooling>();
    }
    public bool CanShoot()
    {
        if (Time.time - lastTimeShoot >= shootFrecuency)
        {
            if (currentAmmunition > 0 || unlimitedAmmunition == true)
            {
                return true;
            }
        }
        return false;
    }
    public void Shoot()
    {
        muzzle.Play();
        lastTimeShoot = Time.time;
        currentAmmunition--;
        GameObject ball = ballPool.GetObject();
        ball.transform.position = outPoint.position;
        ball.transform.rotation = outPoint.rotation;
        ball.GetComponent<Rigidbody>().velocity = outPoint.forward * ballVelocity;
        if(audioSource!=null)
            audioSource.PlayOneShot(soundEffect);
    }

    public void AddAmmo(int amountToAdd)
    {
        currentAmmunition += amountToAdd;
        currentAmmunition = currentAmmunition > maxAmmunition ? maxAmmunition : currentAmmunition;
    }
}
