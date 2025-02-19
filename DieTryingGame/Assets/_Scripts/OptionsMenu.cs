using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    
    public void SetVolume(float volume)
    {
        // Displays volume level as a percentage
        Debug.Log("Current Volume is: " + (volume).ToString("F1"));

        // Set Main volume mixer volume
        audioMixer.SetFloat("volume", volume);
    }

}
