using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BasicEnemyController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] Animator anim;
    [SerializeField] float distance;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!player.isDeath)
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
