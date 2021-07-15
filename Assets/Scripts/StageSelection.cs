using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelection : MonoBehaviour
{
    [SerializeField]
    Texture2D cursorImage;

    [SerializeField]
    List<GameObject> stageImages;

    [SerializeField]
    List<GameObject> stageTexts;

    [SerializeField]
    List<StageController> stageControllers;

    [SerializeField]
    GameObject go1;

    [SerializeField]
    GameObject go2;

    void Awake()
    {
        Cursor.SetCursor(cursorImage, Vector2.zero, CursorMode.Auto);
    }

    void OnEnable()
    {
        foreach(StageController stageController in stageControllers)
        {
            stageController.HoveredOverStage += ShowStageStuff;
            stageController.HideStageImages += HideLevelStuff;
        }
    }

    void OnDisable()
    {
        foreach (StageController stageController in stageControllers)
        {
            stageController.HoveredOverStage -= ShowStageStuff;
            stageController.HideStageImages -= HideLevelStuff;
        }
    }

    void ShowStageStuff(int index)
    {
        foreach(GameObject go in stageImages)
        {
            if(index == stageImages.IndexOf(go))
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }

        foreach(GameObject text in stageTexts)
        {
            if(index == stageTexts.IndexOf(text))
            {
                text.SetActive(true);
            }
            else
            {
                text.SetActive(false);
            }
        }

        go1.SetActive(true);
        go2.SetActive(true);
    }

    void HideLevelStuff()
    {
        foreach(GameObject go in stageImages)
        {
            go.SetActive(false);
        }

        foreach(GameObject text in stageTexts)
        {
            text.SetActive(false);
        }

        go1.SetActive(false);
        go2.SetActive(false);
    }
}
