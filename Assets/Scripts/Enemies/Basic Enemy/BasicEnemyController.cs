using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BasicEnemyController : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    [SerializeField] Animator anim;
    [SerializeField] float distance;
    AIPath aIPath;
    AIDestinationSetter destinationSetter;

    private void Start()
    {
        aIPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!player.GetComponent<PlayerController>().isDeath)
        {
            distance = Vector3.Distance(transform.position, player.transform.position);
            anim.SetFloat("Distance", distance);
        }
        else
        {
            anim.SetFloat("Distance", 41f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !other.GetComponent<PlayerController>().isDeath)
        {
            anim.SetBool("Attacking", true);            
        }
    }
}
