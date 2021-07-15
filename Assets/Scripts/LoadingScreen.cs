using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject spinner;

    [SerializeField]
    private GameObject scrim;

    [SerializeField]
    private GameObject text;

    [SerializeField]
    private RectTransform rectComponent;

    private float turnSpeed = 200f;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(rectComponent != null)
        {
            rectComponent.Rotate(0, 0, -turnSpeed * Time.fixedDeltaTime);
        }
    }

    public void ShowSpinner()
    {
        spinner.SetActive(true);
        scrim.SetActive(true);
        text.SetActive(true);
    }

    public void HideSpinner()
    {
        spinner.SetActive(false);
        scrim.SetActive(false);
        text.SetActive(false);
    }
}
