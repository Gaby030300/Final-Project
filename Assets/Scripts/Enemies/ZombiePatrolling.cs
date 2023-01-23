using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ZombiePatrolling : StateMachineBehaviour
{
    AIDestinationSetter destinationSetter;
    AIPath ai;
    List<Transform> pointsOfPatrolling;
    [SerializeField] float timeToPatrollling;
    int index;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        destinationSetter = animator.GetComponent<AIDestinationSetter>();
        ai = animator.GetComponent<AIPath>();
        pointsOfPatrolling = animator.GetComponent<BasicEnemyController>().pointsToPatroll;
        index = Random.Range(1, pointsOfPatrolling.Count);
        index -= 1;
        destinationSetter.target = pointsOfPatrolling[index].transform;
        ai.canMove = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if((pointsOfPatrolling[index].transform.position - animator.transform.position).magnitude < 1f)
        {
            animator.SetBool("Patrolling",false);
            destinationSetter.target = pointsOfPatrolling[index].transform;
            ai.canMove = true;
        }
    }

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
