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


    [SerializeField] ParticleSystem muzzle;
    [SerializeField] float rayDistance;
    [SerializeField] LineRenderer laser;

    RaycastHit hit;
    private void Awake()
    {
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
        //GameObject ball = ballPool.GetObject();
        //ball.transform.position = outPoint.position;
        //ball.transform.rotation = outPoint.rotation;
        //ball.GetComponent<Rigidbody>().velocity = outPoint.forward * ballVelocity;
        muzzle.Play();
        lastTimeShoot = Time.time;
        currentAmmunition--;
        if(hit.collider != null)
        {
            if (hit.transform.GetComponent<ZombieHealth>() != null )
            {
                hit.transform.GetComponent<ZombieHealth>().EnemyDie();
            }else if (hit.transform.GetComponent<EnemyHealth>() != null)
            {
                hit.transform.GetComponent<EnemyHealth>().RestHealt(5);
            }
        }
        SoundManager.instance.PlaySFX("Shoot");

    }

    private void Update()
    {
        ShootLaser();
    }

    public void ShootLaser()
    {
        
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

    public void PlayerReset()
    {
        currentAmmunition = maxAmmunition;
    }
}
