using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public GameObject optionsMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsMenu.SetActive(!optionsMenu.gameObject.activeSelf);
        }
    }
    public void OnIntroButton()
    {
        SceneManager.LoadScene("Introduction");
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
    public void OnOptionsButton()
    {
        optionsMenu.SetActive(true);
    }
    public void OnExitButton()
    {
        Application.Quit();
    }

}
