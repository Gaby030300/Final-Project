using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public void OnConfigButton()
    {
        configurationPanel.SetActive(true);
    }

    public void OnCloseButton()
    {
        configurationPanel.SetActive(false);
    }
}
