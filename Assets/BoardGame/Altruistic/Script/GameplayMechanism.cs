using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayMechanism : MonoBehaviour
{
    [Header("Script Reference")]
    [SerializeField] TimerMechanism timerMechanism;
    [SerializeField] WordMechanism wordMechanism;
    [Header("UI Reference")]
    [SerializeField] GameObject gameplayScreen;
    [SerializeField] GameObject resultScreen;
    [SerializeField] GameObject timesupScreen;

    [SerializeField] TextMeshProUGUI wordTextEnglish;
    [SerializeField] TextMeshProUGUI wordTextIndonesia;
    public void Inizialize()
    {
        gameplayScreen.SetActive(true);
        timerMechanism.StartTimer();

        wordTextEnglish.text = wordMechanism.GetWordEnglish();
        wordTextIndonesia.text = wordMechanism.GetWordIndonesia();
    }

    public void TimesUp()
    {
        gameplayScreen.SetActive(false);
        resultScreen.SetActive(true);
        timesupScreen.SetActive(true);


    }

    private void Update()
    {
        if (timerMechanism.GetGameOver())
        {
            TimesUp();
        }
    }

    public void PauseGame()
    {

    }

    public void ResumeGame()
    {

    }
}
