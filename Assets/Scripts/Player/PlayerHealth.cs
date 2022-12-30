using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int currentHealt;
    [SerializeField] int maxHealt;
    Rigidbody player;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        player.AddForce(Vector3.back * (healtToLoss / 2), ForceMode.Impulse);
        currentHealt -= healtToLoss;
        if (currentHealt <= 0)
            PlayerDie();
    }

    public void PlayerDie()
    {
        gameObject.SetActive(false);
    }
}
