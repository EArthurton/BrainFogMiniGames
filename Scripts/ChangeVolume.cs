using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class ChangeVolume : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider, sfxSlider;

    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
    }

    public void MusicLevel(float musicValue)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10 (musicValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicValue);
    }

    public void SFXLevel(float sfxValue)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(sfxValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sfxValue);
    }
}
