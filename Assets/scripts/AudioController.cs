using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioController : MonoBehaviour
{

    public static AudioController instance;

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates
        }
    }


    //AudioSources
    [Header("------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;


    //AudioClips
    [Header("------- Audio Clips --------")]
    public AudioClip backgroundStartMenue;
    public AudioClip backgroundGamePlay;
    public AudioClip bear;
    public AudioClip build;
    public AudioClip chicken;
    public AudioClip dog;
    public AudioClip explosion;
    public AudioClip frog;
    public AudioClip lose;
    public AudioClip player_hurt;
    public AudioClip rat;
    public AudioClip snake;
    public AudioClip wrench_hit;
    public AudioClip cannon;
    public AudioClip catapult;





    //play background music for given scene
    public void OnSceneLoaded(int index)
    {
        // Check the scene name and set the appropriate audio clip
        switch (index)
        {
            case 0:
                musicSource.clip = backgroundStartMenue;
                break;
            case 1:
                musicSource.clip = backgroundGamePlay;
                break;
            default:
                musicSource.clip = backgroundStartMenue; // Fallback or default
                break;
        }

        // Play the selected clip
        musicSource.Play();
    }

    //play given sound effect
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    //play start menue music on start up
    private void Start()
    {
        // Optionally call OnSceneLoaded for the initial scene
        OnSceneLoaded(SceneManager.GetActiveScene().buildIndex);
    }



}
