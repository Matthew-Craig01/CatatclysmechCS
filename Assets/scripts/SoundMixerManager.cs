using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundMixerManager : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;



    //set master volume
    public void setMasterVolume(float vLevel)
    {
        audioMixer.SetFloat("MasterVolume",vLevel);

    }

    //set music volume
    public void setMusicVolume(float vLevel)
    {
        audioMixer.SetFloat("MusicVolume", vLevel);
 
    }

    //set SFX volume
    public void setSFXVolume(float vLevel)
    {
        audioMixer.SetFloat("SFXVolume", vLevel);

    }


    

}
