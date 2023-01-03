using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    [SerializeField] ShootController shootController;
    [SerializeField] TextMeshProUGUI textBullet;
    [SerializeField] Image healtBar;

    // Update is called once per frame
    void Update()
    {
        textBullet.text = "Bullets: "+shootController.currentAmmunition + " / " + shootController.maxAmmunition;
        healtBar.fillAmount = playerHealth.currentHealt/100;
    }
}
