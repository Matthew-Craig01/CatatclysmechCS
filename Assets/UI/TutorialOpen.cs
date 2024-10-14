using UnityEngine;
using UnityEngine.UI;

public class TutorialOpen : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject tutorial;
    public GameObject homeUI;
    public bool tutorialOpen;

    void Start()
    {
    }

    public void OpenTutorial()
    {
        Debug.Log("Clicked Tutorial Button");
        tutorialText.SetActive(true);
        tutorial.SetActive(true);
        homeUI.SetActive(false);
        tutorialOpen = true;
    }

    public void CloseTutorial()
    {
        Debug.Log("Close button");
        tutorialText.SetActive(false);
        tutorial.SetActive(false);
        homeUI.SetActive(true);
        tutorialOpen = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && tutorialOpen)
        {
            CloseTutorial();
        }
    }
}
