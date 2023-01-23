using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfItem
{
    heatlhItem,
    ammoItem
}

public class Item : MonoBehaviour
{
    [SerializeField] TypeOfItem typeOfItem;
    [SerializeField] int amountToAdd;
    ShootController shootController;
    PlayerHealth playerHealth;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (typeOfItem.Equals(TypeOfItem.heatlhItem))
            {
                playerHealth = other.GetComponent<PlayerHealth>();
                if(playerHealth.currentHealt < playerHealth.maxHealt)
                {
                    SoundManager.instance.PlaySFX("Medikit");
                    playerHealth.AddHealt(amountToAdd);                                        
                    gameObject.SetActive(false);
                }
            }
            else
            {
                shootController = other.GetComponent<ShootController>();
                if (shootController.currentAmmunition < shootController.maxAmmunition)
                {
                    SoundManager.instance.PlaySFX("RechargeGun");
                    shootController.AddAmmo(amountToAdd);
                    gameObject.SetActive(false);
                }
            }
        }
    }

}
