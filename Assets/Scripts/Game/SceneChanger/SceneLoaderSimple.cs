using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneLoaderSimple : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] UnityEvent loadScreenEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChargeScene();
        }
    }

    public void ChargeScene()
    {
        loadScreenEvent.Invoke();
        SceneManager.LoadScene(sceneName);
    }
}
