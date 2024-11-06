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

     bool gameOver = false;

    [ContextMenu("Start Timer")]
    public void StartTimer()
    {
        timeRemaining = duration;
        timerIsRunning = true;
        gameOver = false;
    }

    public void ResumeTimer()
    {
        timerIsRunning = true;
    }

    public void PauseTimer()
    {
        timerIsRunning = false;
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
                gameOver = true;
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void ResetGameOver()
    {
        gameOver = false;
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
