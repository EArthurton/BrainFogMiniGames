using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //public float timeRemaining;
    public static float countUpTimer;
    public bool timerIsRunning = false;
    public Text timeText;

    void Start()
    {
        timeText = GameObject.Find("Time").GetComponent<Text>();
        timerIsRunning = true;

        if (SceneName.previousLevel == "CInstructions")
        {
            countUpTimer = 0.0f;
        }
    }

    void Update()
    {
        countUpTimer += Time.deltaTime;
        DisplayTime(countUpTimer);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(countUpTimer / 60);
        float seconds = Mathf.FloorToInt(countUpTimer % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}