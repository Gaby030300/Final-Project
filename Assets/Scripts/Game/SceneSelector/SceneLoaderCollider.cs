using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfScene
{
    puzzleScene,
    insideScene
}


public class SceneLoaderCollider : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] TypeOfScene typeOfScene;
    [SerializeField] string sceneName;
    [SerializeField] BoxCollider detector;
    [SerializeField] Transform player;
    [SerializeField] Transform pointToTeleport;
    [SerializeField] GameObject toDesActivate;

    private void Start()
    {
        sceneLoader = SceneLoader.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(typeOfScene.Equals(TypeOfScene.puzzleScene))
            {
                detector.enabled = false;                
            }
            else if(typeOfScene.Equals(TypeOfScene.insideScene))
            {
                player.position = pointToTeleport.position;
                toDesActivate.SetActive(false);
            }
            sceneLoader.LoadScene(sceneName);
        }
    }        
}
