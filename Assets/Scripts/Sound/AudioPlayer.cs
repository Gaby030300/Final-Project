using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip sound { get; set; }
    AudioSource audioController;

    private void Awake()
    {
        audioController = GetComponent<AudioSource>();
    }

    public void PlaySoundOne()
    {
        audioController.PlayOneShot(sound);
    }
}
