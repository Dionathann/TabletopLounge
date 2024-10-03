using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TimerMechanism : MonoBehaviour
{
    public float duration;
    private float timeRemaining;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    [ContextMenu("Start Timer")]
    public void StartTimer()
    {
        timeRemaining = duration;
        timerIsRunning = true;
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time's up!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
