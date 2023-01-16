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
        textBullet.text = "Bullets: "+shootController.currentAmmunition + " / " + shootController.maxAmmunition;
        healtBar.fillAmount = playerHealth.currentHealt/100;
    }
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnConfigButton(GameObject player)
    {
        configurationPanel.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;        
    }

    public void OnCloseButton(GameObject player)
    {
        configurationPanel.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;        
    }    
    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
