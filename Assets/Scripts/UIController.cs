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

    void Update()
    {
        textBullet.text = shootController.currentAmmunition + " / " + shootController.maxAmmunition;
        healtBar.fillAmount = playerHealth.currentHealt/100;

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            configurationPanel.SetActive(true);
        }
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
