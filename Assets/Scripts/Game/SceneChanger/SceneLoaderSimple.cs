using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderSimple : MonoBehaviour
{
    [SerializeField] string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ChargeScene();
        }
    }

    public void ChargeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
