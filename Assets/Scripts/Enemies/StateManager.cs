using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class StateManager : MonoBehaviour
{
    [SerializeField] State currentState;
    [SerializeField] AIPath pathFinder;
    [SerializeField] AIDestinationSetter destinationSetter;

    void LateUpdate()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();
        
        if (nextState != null)
        {
            //Switch to next state
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }

    public void StartToMove()
    {
        pathFinder.canMove = true;
    }

    public void StopMoving()
    {
        pathFinder.canMove = false;
    }

    public void ChangeDestination(Transform destination)
    {
        destinationSetter.target = destination;
    }
}
