using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

   // public static SceneController instance;


    
    //load game scene
    public void loadScene(int index) 
    {
        SceneManager.LoadScene(index);
        AudioController.instance?.OnSceneLoaded(index);
        Time.timeScale = 1.0f;
    }
    //on click exit button exit game
    public void onExit()
    {
        Application.Quit();
    }

}
