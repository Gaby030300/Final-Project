using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SoundPanelController : MonoBehaviour
{
    public static SoundPanelController instance;

    public Slider _musicSlider, _sfxSlider;

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicSave", 1f);
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxSave", 1f);
    }
    private void Update()
    {
        MusicVolume();
        SFXVolume();
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SaveVolume()
    {        
        PlayerPrefs.SetFloat("musicSave", _musicSlider.value);
        PlayerPrefs.SetFloat("sfxSave", _sfxSlider.value);
    }

    public void ToggleMusic()
    {
        SoundManager.instance.ToggleMusic();
    }
    public void ToggleSFX()
    {
        SoundManager.instance.ToggleSFX();
    }
    public void MusicVolume()
    {
        SoundManager.instance.MusicVolume(_musicSlider.value);
        PlayerPrefs.SetFloat("musicSave", _musicSlider.value);
    }
    public void SFXVolume()
    {
        SoundManager.instance.SFXVolume(_sfxSlider.value);        
    }
 
}
