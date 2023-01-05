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
                    playerHealth.AddHealt(amountToAdd);                    
                    Destroy(gameObject);
                }
            }
            else
            {
                shootController = other.GetComponent<ShootController>();
                if (shootController.currentAmmunition < shootController.maxAmmunition)
                {
                    shootController.AddAmmo(amountToAdd);
                    Destroy(gameObject);
                }
            }
        }
    }

}
