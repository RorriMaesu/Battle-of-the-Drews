using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsController : MonoBehaviour
{
    [SerializeField]
    List<GameObject> livesObjects;

    [SerializeField]
    List<GameObject> timerObjects;

    [SerializeField]
    Button forwardLivesButton;

    [SerializeField]
    Button backLivesButton;

    [SerializeField]
    Button forwardTimeButton;

    [SerializeField]
    Button backTimeButton;

    [SerializeField]
    Button backButton;

    int livesIndex = 2;
    int timeIndex = 0;

    void OnEnable()
    {
        forwardLivesButton.onClick.AddListener(HandleLivesForward);
        backLivesButton.onClick.AddListener(HandleLivesBack);
        forwardTimeButton.onClick.AddListener(HandleTimeForward);
        backTimeButton.onClick.AddListener(HandleTimeBack);
        DisplayObjectAtIndex(livesObjects, livesIndex);
        DisplayObjectAtIndex(timerObjects, timeIndex);
        backButton.onClick.AddListener(HandleBackButtonClicked);
    }

    void OnDisable()
    {
        forwardLivesButton.onClick.RemoveListener(HandleLivesForward);
        backLivesButton.onClick.RemoveListener(HandleLivesBack);
        forwardTimeButton.onClick.RemoveListener(HandleTimeForward);
        backTimeButton.onClick.RemoveListener(HandleTimeBack);
        backButton.onClick.RemoveListener(HandleBackButtonClicked);
    }

    void HandleLivesForward()
    {
        if(livesIndex < livesObjects.Count - 1)
        {
            livesIndex++;
        }
        else
        {
            livesIndex = 0;
        }

        DisplayObjectAtIndex(livesObjects, livesIndex);
        GameState.lives = livesIndex + 1;
    }

    void HandleLivesBack()
    {
        if(livesIndex > 0)
        {
            livesIndex--;
        }
        else
        {
            livesIndex = livesObjects.Count - 1;
        }

        DisplayObjectAtIndex(livesObjects, livesIndex);
        GameState.lives = livesIndex + 1;
    }

    void HandleTimeForward()
    {
        if(timeIndex < timerObjects.Count - 1)
        {
            timeIndex++;
        }
        else
        {
            timeIndex = 0;
        }

        DisplayObjectAtIndex(timerObjects, timeIndex);
        GameState.time = timeIndex + 1;
    }

    void HandleTimeBack()
    {
        if(timeIndex > 0)
        {
            timeIndex--;
        }
        else
        {
            timeIndex = timerObjects.Count - 1;
        }

        DisplayObjectAtIndex(timerObjects, timeIndex);
        GameState.time = timeIndex + 1;
    }

    void DisplayObjectAtIndex(List<GameObject> list, int index)
    {
        for(int i = 0; i < list.Count; i++)
        {
            if(i == index)
            {
                list[i].SetActive(true);
            }
            else
            {
                list[i].SetActive(false);
            }
        }
    }

    void HandleBackButtonClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }


}
