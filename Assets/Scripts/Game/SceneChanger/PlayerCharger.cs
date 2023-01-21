using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsToUpdate
{
    SceneLoader,
    player
}

public class PlayerCharger : MonoBehaviour
{
    [SerializeField] StatsToUpdate stats;
    PlayerHealth health;
    ShootController bullets;
    PlayerCharger playerCharger;
    GameObject sceneLoader;

    public float healthAmount;
    public int bulletsAmount;

    private void Start()
    {
        if (stats.Equals(StatsToUpdate.SceneLoader))
        {
            health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
            bullets = GameObject.FindGameObjectWithTag("Player").GetComponent<ShootController>();
            healthAmount = health.currentHealt;
            bulletsAmount = bullets.currentAmmunition;
        }
        else if(stats.Equals(StatsToUpdate.player))
        {
            health = GetComponent<PlayerHealth>();
            bullets = GetComponent<ShootController>();
            playerCharger = SceneLoader.instance.GetComponent<PlayerCharger>();

            sceneLoader = GameObject.FindGameObjectWithTag("SceneManagerTag");

            health.currentHealt = sceneLoader.GetComponent<PlayerCharger>().healthAmount;
            bullets.currentAmmunition = sceneLoader.GetComponent<PlayerCharger>().bulletsAmount;
        }
    }
}
