using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleVisibleRoofs : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsRoof;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject o in objectsRoof)
            {
                o.SetActive(false);
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject o in objectsRoof)
            {
                o.SetActive(true);
            }
        }
    }


}
