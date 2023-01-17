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
    [SerializeField] float rayDistance;
    [SerializeField] LineRenderer laser;


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
    public void DrawRay(Vector2 startPosition, Vector2 endPosition)
    {
        laser.SetPosition(0, startPosition);
        laser.SetPosition(1, endPosition);
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
        RaycastHit hit;
        if (Physics.Raycast(outPoint.position, outPoint.forward, out hit, rayDistance))
        {
            Debug.Log(hit.collider.name);
        }
        if (audioSource!=null)
            audioSource.PlayOneShot(soundEffect);
    }

    private void Update()
    {
        ShootLaser();
    }

    public void ShootLaser()
    {
        RaycastHit hit;
        if (Physics.Raycast(outPoint.position, outPoint.forward, out hit, rayDistance))
        {
            laser.SetPosition(0,outPoint.position);
            laser.SetPosition(1,hit.point);
        }
        else
        {
            laser.SetPosition(0,outPoint.position);
            laser.SetPosition(1,outPoint.position+outPoint.forward*rayDistance);
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawRay(outPoint.position,outPoint.forward*50f);
    //}

    public void AddAmmo(int amountToAdd)
    {
        currentAmmunition += amountToAdd;
        currentAmmunition = currentAmmunition > maxAmmunition ? maxAmmunition : currentAmmunition;
    }

    
}
