using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicityCloud : MonoBehaviour
{
    [SerializeField] float timeToAttack, lifeTime, speedCloud;
    float currentTime, currentTimeLife;
    bool canAttack;

    private void Start()
    {
        canAttack = true;
        currentTime = 0;
        currentTimeLife = lifeTime;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speedCloud * Time.deltaTime);
        currentTimeLife -= Time.deltaTime;
        if (currentTimeLife <= 0)
        {
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canAttack)
        {
            canAttack = false;
            other.GetComponent<PlayerHealth>().RestHealt(20);
            StartCoroutine(CanAttackAgain());
        }
    }

    IEnumerator CanAttackAgain()
    {
        yield return new WaitForSeconds(timeToAttack);
        canAttack = true;
    }
}
