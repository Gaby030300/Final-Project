using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public float currentHealt;
    public int maxHealt;
    [SerializeField] Rigidbody player;
    [SerializeField] PlayerController playerController;
    AudioSource audioSource;
    [SerializeField] AudioClip soundHurt,soundDie;

    [SerializeField] UnityEvent gameOverEvent;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Rigidbody>();
        currentHealt = maxHealt;
    }

    public void RestHealt(int healtToLoss)
    {
        playerController.GetComponent<PlayerController>().StopMoving();
        player.AddRelativeForce(Vector3.back * (5 / 2), ForceMode.Impulse);
        currentHealt -= healtToLoss;
        audioSource.PlayOneShot(soundHurt);
        if (currentHealt <= 0)
            PlayerDie();
    }
    
    public void AddHealt(int healtToLoss)
    {
        currentHealt += healtToLoss;
        if (currentHealt > maxHealt)
            currentHealt = maxHealt;
    }

    public void PlayerDie()
    {
        gameOverEvent.Invoke();
        audioSource.PlayOneShot(soundDie);
        playerController.DieAnimation();
        //gameObject.SetActive(false);
    }
}
