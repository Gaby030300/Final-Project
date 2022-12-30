using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class BasicEnemyController : MonoBehaviour
{
    Transform player;
    Rigidbody rb;
    [SerializeField] Animator anim;
    [SerializeField] float distance;
    AIPath aIPath;
    AIDestinationSetter destinationSetter;

    private void Start()
    {
        aIPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        anim.SetFloat("Distance", distance);
    }

    public void StartAttack()
    {
        anim.SetBool("Attacking", true);
    }
    public void StopAttack()
    {
        anim.SetBool("Attacking",false);
    }
}
