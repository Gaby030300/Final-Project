using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] string sceneName;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneLoader = SceneLoader.instance;
            sceneLoader.UnLoadScene(sceneName);
        }
    }

}
