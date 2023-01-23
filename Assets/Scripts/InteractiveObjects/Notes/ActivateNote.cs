using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateNote : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject instruction;
    private void Update()
    {
        if (triggerActive && Input.GetKeyDown(KeyCode.E))
        {
            ActiveNote();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            instruction.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            instruction.SetActive(false);
        }
    }

    public void ActiveNote()
    {
        note.SetActive(!note.gameObject.activeSelf);
        SoundManager.instance.PlaySFX("Paper");
        if (note.gameObject.activeSelf == true)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
