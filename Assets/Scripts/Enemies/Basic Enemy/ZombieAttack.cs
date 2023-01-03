using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : StateMachineBehaviour
{
    ZombieAttackArea zombieAttackArea;
    GameObject player;
    [SerializeField] float timeToAttack;
    float currentTimeToAttack;
    [SerializeField] int damage;
    [SerializeField] float forceToPush;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        zombieAttackArea = animator.GetComponent<ZombieAttackArea>();
        player = GameObject.FindGameObjectWithTag("Player");
        currentTimeToAttack = timeToAttack;
        player.GetComponent<PlayerHealth>().RestHealt(damage);
        player.GetComponent<Rigidbody>().AddRelativeForce((Vector3.back + player.transform.position).normalized * forceToPush, ForceMode.Impulse);
        animator.SetBool("Attacking", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
        
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
