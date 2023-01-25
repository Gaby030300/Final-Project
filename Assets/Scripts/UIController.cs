using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class UIController : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] ShootController shootController;
    [SerializeField] TextMeshProUGUI textBullet;
    [SerializeField] Image healtBar;
    [SerializeField] GameObject configurationPanel;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;        
    }

    void Update()
    {
        textBullet.text = shootController.currentAmmunition + "/" + shootController.maxAmmunition;
        healtBar.fillAmount = playerHealth.currentHealt/100;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            configurationPanel.SetActive(!configurationPanel.gameObject.activeSelf);
            if(configurationPanel.gameObject.activeSelf == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
            
        }
    }
    public void OnCloseButton()
    {
        configurationPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
   
    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
