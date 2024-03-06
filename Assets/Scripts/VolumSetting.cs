using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Text numberBgMusic;
    [SerializeField] private Text numberSFX;

    public void Start()
    {
        if (PlayerPrefs.HasKey("bgMusicVolume"))
        {
            loadVolume();
        }else
        {
            setBgMusicVolume();
            setSFXVolume();
        }
    }

    public void setBgMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("bgMusic", Mathf.Log10(volume) *20);
        PlayerPrefs.SetFloat("bgMusicVolume", volume);
        numberBgMusic.text = (int)(volume * 100) + "";
    }

    public void setSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
        numberSFX.text = (int)(volume * 100) + "";
    }

    private void loadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("bgMusicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        setBgMusicVolume();
        setSFXVolume();
    }
}
