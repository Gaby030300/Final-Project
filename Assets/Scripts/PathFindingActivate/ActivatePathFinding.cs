using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePathFinding : MonoBehaviour
{
    [SerializeField] GameObject pathFindingToActivate, pathFindingToDesactivate;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pathFindingToDesactivate.SetActive(false);
            pathFindingToActivate.SetActive(true);
        }
    }
}
