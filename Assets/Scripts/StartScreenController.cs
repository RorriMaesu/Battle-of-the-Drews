using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    void OnEnable()
    {
        startButton.onClick.AddListener(HandleStartButtonClicked);
        GameState.lives = 3;
        GameState.time = 0;
    }

    void OnDisable()
    {
        startButton.onClick.RemoveListener(HandleStartButtonClicked);
    }

    void HandleStartButtonClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
