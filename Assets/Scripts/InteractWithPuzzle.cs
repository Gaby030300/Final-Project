using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithPuzzle : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] string sceneName;
    [SerializeField] List<GameObject> listToDesActivate;
    [SerializeField] BoxCollider detector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject i in listToDesActivate)
            {
                i.SetActive(false);
            }
            detector.enabled = false;
            sceneLoader.LoadScene(sceneName);
        }
    }

    public void ActivateObjects()
    {
        foreach (GameObject i in listToDesActivate)
        {
            i.SetActive(true);
        }
    }
}
