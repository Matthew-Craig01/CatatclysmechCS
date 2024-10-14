using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    public static SoundEffectsManager instance;
    [SerializeField] private AudioSource m_AudioSource;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
           
    }
    public void PlaySoundCLip(AudioClip audio_clip, Transform spawnt, float volume)
    {
        //spawn in game object
        AudioSource audio_source = Instantiate(m_AudioSource, spawnt.position, Quaternion.identity);


        //assign audio clip
        audio_source.clip = audio_clip;

        //assign volume
        audio_source.volume = volume;

        //play sound
        audio_source.Play();

        //get audio clip length
        float cliplength = audio_source.clip.length;

        //destroy clip after its finished playing
        Destroy(audio_source.gameObject, cliplength);
    }
}
