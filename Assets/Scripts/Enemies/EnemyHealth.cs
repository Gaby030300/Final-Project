using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHealt;
    [SerializeField] int maxHealt;

    private void Start()
    {
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        currentHealt -= healtToLoss;
        if (currentHealt <= 0)
            EnemyDie();
    }

    public void EnemyDie()
    {
        gameObject.SetActive(false);
    }
}
