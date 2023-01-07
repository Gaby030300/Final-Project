using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PanelWireController : MonoBehaviour
{
    public GameObject panel;

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Q) && other.CompareTag("Player"))
        { 
            Debug.Log("Entro");
            panel.SetActive(true);
        }
        
    }
}
