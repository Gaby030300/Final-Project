using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealt;
    public int maxHealt;
    Rigidbody player;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        player.AddRelativeForce(Vector3.back * (healtToLoss / 2), ForceMode.Impulse);
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
        gameObject.SetActive(false);
    }
}
