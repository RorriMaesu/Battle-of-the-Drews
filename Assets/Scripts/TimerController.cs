using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI timer;

    private float time;
    private string minutes;
    private string seconds;

    void Start()
    {
        minutes = "";
        seconds = "";

        if(GameState.time == 0)
        {
            time = 60f;
        }
        else if(GameState.time == 1)
        {
            time = 120f;
        }
        else if(GameState.time == 2)
        {
            time = 180f;
        }
        else
        {
            timer.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        minutes = Mathf.Floor(time / 60).ToString("00");
        seconds = Mathf.Floor(time % 60).ToString("00");
        timer.text = minutes + " : " + seconds;

        if(Mathf.Floor(time / 60) <= 0 && Mathf.Floor(time % 60) <= 0 && GameState.time != 3)
        {
            SceneManager.LoadSceneAsync("CelebrationScreen");
        }
    }
}
