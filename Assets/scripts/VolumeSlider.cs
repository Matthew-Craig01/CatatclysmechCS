using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    private Slider slider; // Reference to the Slider component
    private string sliderName;
    private float currentVolume;
    [SerializeField] private AudioMixer audioMixer;

    private void Awake()
    {
        // Get the Slider component attached to this GameObject
        slider = GetComponent<Slider>();
        sliderName = gameObject.name;
    }

    private void Start()
    {
        switch (sliderName)
        {
            case "slider Master":
                audioMixer.GetFloat("MasterVolume", out currentVolume);
                break;
            case "slider music":
                audioMixer.GetFloat("MusicVolume", out currentVolume);
                break;
            case "slider SFX":
                audioMixer.GetFloat("SFXVolume", out currentVolume);
                break;
            default:
                currentVolume = -10f; // Fallback or default
                break;
        }
        slider.value = currentVolume;


    }
}
