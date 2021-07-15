using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public event Action<int> HoveredOverStage;
    public event Action HideStageImages;
    [SerializeField] int index;
    LoadingScreen loadingScreen;

    void Awake()
    {
        loadingScreen = GameObject.Find("LoadingCanvas").GetComponent<LoadingScreen>();
        if(loadingScreen != null)
        {
            loadingScreen.HideSpinner();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(index == 0)
        {
            SceneManager.LoadSceneAsync("AndrewsCastle");
        }
        else if(index == 1)
        {
            SceneManager.LoadSceneAsync("Battlefield");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        HoveredOverStage?.Invoke(index);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideStageImages?.Invoke();
    }
}
