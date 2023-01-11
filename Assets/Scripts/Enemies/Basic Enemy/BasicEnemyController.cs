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
        distance = Vector3.Distance(transform.position, player.transform.position);
        anim.SetFloat("Distance", distance);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Attacking", true);            
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        anim.SetBool("Attacking",false);            
    //    }
    //}
}
