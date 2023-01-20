using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckInteract : MonoBehaviour
{
    public bool interacting;
    PlayerController player;

    private void Awake()
    {
        player = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if(player.canMove)
            CheckInteracting();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interactable") && interacting)
        {
            other.GetComponent<Activator>().ActivateEvent();
        }
    }

    public void CheckInteracting()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interacting = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            interacting = false;
        }
    }
}
