using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenue;
   // [SerializeField] GameObject buyMenue;
  //  bool wasActive = false;

    void Update()
    {
        // Check if the Escape key was pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the settings menu
            if (settingsMenue.activeSelf)
            {
                Resume(); // If the menu is active, resume the game
            }
            else
            {
                Pause(); // If the menu is not active, pause the game
            }
        }
    }






    public void Resume()

    {
        
        settingsMenue.SetActive(false);
        Time.timeScale = 1f;
      //  if (wasActive)
      //  {
       //     wasActive = false;
       //     buyMenue.SetActive(true);
       //     Time.timeScale = 0f;
      //  }
        
    }


    public void Pause()
    {
      //  if (buyMenue.activeSelf == true)
      //  {
       //     buyMenue.SetActive(false);
       //     wasActive = true;
      //  }
        settingsMenue.SetActive(true);
        Time.timeScale = 0; 
    }

    

    

}
