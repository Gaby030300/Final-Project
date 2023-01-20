using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public GameObject optionsMenu;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            optionsMenu.SetActive(true);
        }
    }
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level1Prototype Daniel");
    }
    public void OnCreditsButton()
    {
        SceneManager.LoadScene("Credits");
    }
    public void OnExitButton()
    {
        Application.Quit();
    }

}
