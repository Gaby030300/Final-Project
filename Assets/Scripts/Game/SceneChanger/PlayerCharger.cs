using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharger : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        player = PlayerController.instance.gameObject;
        player.transform.position = transform.position;
        player.SetActive(true);
    }
}
