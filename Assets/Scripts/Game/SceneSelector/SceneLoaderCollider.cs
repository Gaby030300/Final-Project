using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum TypeOfScene
{
    puzzleScene,
    insideScene
}


public class SceneLoaderCollider : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] TypeOfScene typeOfScene;
    [SerializeField] string sceneName;
    [SerializeField] BoxCollider detector;
    [SerializeField] Transform player;
    [SerializeField] Transform pointToTeleport;
    [SerializeField] List<GameObject> toDesActivate,toActivate;
    [SerializeField] OpenMechanismWires openMechanismWires;
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
                openMechanismWires.AllowToMove();
                detector.enabled = false;                
            }
            else if(typeOfScene.Equals(TypeOfScene.insideScene))
            {
                DeActivateObjects();
                //ActivateObjects();
            }
            other.gameObject.SetActive(false);
            sceneLoader.LoadScene(sceneName);
        }
    }


    public void DeActivateObjects()
    {
        foreach (GameObject i in toDesActivate)
        {
            i.SetActive(false);
        }
    }
    public void ActivateObjects()
    {
        player.position = pointToTeleport.position;
        foreach (GameObject i in toActivate)
        {
            i.SetActive(true);
        }
    }
}
