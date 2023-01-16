using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    [SerializeField] List<GameObject> listToDesActivate;
    [SerializeField] OpenMechanismWires openMechanism;
    private void Awake()
    {
        if(instance != null)
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
        DeActivateObjects();
        SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);
    }

    public void UnLoadScene(string sceneName)
    {
        if (sceneName.Equals("Assets/Scenes/Fix Wires 1"))
        {
            openMechanism.AllowToMove();
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
}
