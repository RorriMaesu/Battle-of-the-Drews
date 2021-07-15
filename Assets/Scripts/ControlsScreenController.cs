using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsScreenController : MonoBehaviour
{
    [SerializeField]
    Button backButton;

    void OnEnable()
    {
        backButton.onClick.AddListener(HandleBackButtonClicked);
    }

    void OnDisable()
    {
        backButton.onClick.RemoveListener(HandleBackButtonClicked);
    }

    void HandleBackButtonClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
