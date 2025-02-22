using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer AudioMixer;
    public Slider VolumeSlider;
    public TextMeshProUGUI VolumeText;

    public void Start()
    {
        SetVolumeText();
    }

    public void SetVolume(float volume)
    {
        // Displays volume level as a percentage
        Debug.Log("Current Volume is: " + (volume).ToString("F1"));

        // Set Main volume mixer volume
        AudioMixer.SetFloat("Volume", volume);
    }

    public void SetVolumeText()
    {
        float volume = VolumeSlider.value + 20; //TODO remap this instead of flat -80 to 20 decibels
        VolumeText.text = volume.ToString("F1");
    }

    public void SaveSettings()
    {
        SetVolume(VolumeSlider.value);
    }
}
