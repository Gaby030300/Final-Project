using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    [SerializeField] List<GameObject> listToDesActivate;
    [SerializeField] List<GameObject> listOfPlayer;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void LoadScene(string sceneName)
    {
        if (sceneName.Equals("Fix Wires 1"))
        {
            DeActivateObjectsP();
        }
        DeActivateObjects();
        SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
    }

    public void UnLoadScene(string sceneName)
    {
        if (sceneName.Equals("InteriorScene1FInal"))
        {
            GameObject.FindObjectOfType<SceneLoaderCollider>().ActivateObjects();
        }
        if (sceneName.Equals("Fix Wires 1"))
        {
            ActivateObjectsP();
        }
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(sceneName));
        ActivateObjects();
    }

    public void DeActivateObjects()
    {
        foreach (GameObject i in listToDesActivate)
        {
            i.SetActive(false);
        }
    }
    public void ActivateObjects()
    {
        foreach (GameObject i in listToDesActivate)
        {
            i.SetActive(true);
        }
    }
    public void DeActivateObjectsP()
    {
        foreach (GameObject i in listOfPlayer)
        {
            i.SetActive(false);
        }
    }
    public void ActivateObjectsP()
    {
        foreach (GameObject i in listOfPlayer)
        {
            i.SetActive(true);
        }
    }
}
