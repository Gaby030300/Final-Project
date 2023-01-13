using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealt;
    public int maxHealt;
    [SerializeField] Rigidbody player;
    [SerializeField] PlayerController playerController;
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Rigidbody>();
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        playerController.GetComponent<PlayerController>().StopMoving();
        player.AddRelativeForce(Vector3.back * (5 / 2), ForceMode.Impulse);
        currentHealt -= healtToLoss;
        if (currentHealt <= 0)
            PlayerDie();
    }
    
    public void AddHealt(int healtToLoss)
    {
        currentHealt += healtToLoss;
        if (currentHealt > maxHealt)
            currentHealt = maxHealt;
    }

    public void PlayerDie()
    {
        playerController.DieAnimation();
        //gameObject.SetActive(false);
    }
}
