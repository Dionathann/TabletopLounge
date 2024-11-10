using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GtWGameplayMechanism : MonoBehaviour
{
    [SerializeField] NameHolder nameHolder;
    [SerializeField] TimerMechanism timerMechanism;
    [SerializeField] GtWWordData wordData;
    [SerializeField] CategoryDisplayer categoryDisplayer;
    

    [Header("UI Reference")]
    [SerializeField] GameObject nameDisplayerPanel;
    [SerializeField] GameObject gameplayScreenPanel;
    [SerializeField] TextMeshProUGUI wordText;

    [Header("Button References")]
    [SerializeField] Button correctButton;
    [SerializeField] Button skipButton;

    public List<string> tempShuffledWordList;

    private List<string> currentSessionPlayerList;

    public AudioClip finishSound;
    public AudioSource SFXSound;

    private int currentIndexPlayer;

    private int correctCounter;

    private int skipCounter;

    private int currentWordIndex;

    private bool isCorrectButtonHeld = false;

    private bool isSkipButtonHeld = false;

    public void Inizialize()
    {
        RandomPlayerSession();

        //RandomizeTempWordList();

        currentWordIndex = 0;
    }

    [ContextMenu("Start Game")]
    public void GameStart()
    {
        GtWResultDisplay.gameOverFlag = false;

        correctCounter = 0;

        skipCounter = 0;

        gameplayScreenPanel.SetActive(true);
        
        timerMechanism.StartTimer();

        RandomizeTempWordList();

        DisplayNextWord();
    }

    public List<string> GetPlayerNameList()
    {
        return currentSessionPlayerList;
    }

    [ContextMenu("Test random")]
    public int GetIndexPlayer()
    {
        return currentIndexPlayer;
    }


    public void RandomPlayerSession()
    {
        currentSessionPlayerList?.Clear();

        currentSessionPlayerList = new List<string>(nameHolder.playerNameList);

        for (int i = 0; i < currentSessionPlayerList.Count; i++)
        {
            string temp = currentSessionPlayerList[i];

            int index = Random.Range(0, currentSessionPlayerList.Count);

            currentSessionPlayerList[i] = currentSessionPlayerList[index];

            currentSessionPlayerList[index] = temp;
        }
        currentIndexPlayer = 0;
    }

    [ContextMenu("Test Randomize Temp List")]
    public void RandomizeTempWordList()
    {
        tempShuffledWordList?.Clear();

        var playableCategory = categoryDisplayer.GetPlayableCategoryList();

        Debug.Log(playableCategory.wordList.Count);

        tempShuffledWordList = new List<string>(playableCategory.wordList);

        for (int i = 0; i < tempShuffledWordList.Count; i++)
        {
            string temp = tempShuffledWordList[i];

            int index = Random.Range(0, tempShuffledWordList.Count);

            tempShuffledWordList[i] = tempShuffledWordList[index];

            tempShuffledWordList[index] = temp;
        }
    }

    /*public string GetNextWord(int index)
    {
        if(index >= tempShuffledWordList.Count)
        {
            return tempShuffledWordList[0];
        }

        return tempShuffledWordList[index];
    }*/

    public void DisplayNextWord()
    {
        if (currentWordIndex >= tempShuffledWordList.Count)
        {
            currentWordIndex = 0; 
        }
        wordText.text = tempShuffledWordList[currentWordIndex];
    }

    public void CorrectButtonPressed()
    {
        isCorrectButtonHeld = true;

        skipButton.interactable = false;
    }
    public void SkipButtonPressed()
    {
        isSkipButtonHeld = true;

        correctButton.interactable = false;
    }

    public void CorrectButtonReleased()
    {
        isCorrectButtonHeld = false;

        skipButton.interactable = true;
    }

    public void SkipButtonReleased()
    {
        isSkipButtonHeld = false;

        correctButton.interactable = true;
    }

    public void CorrectButton()
    {
        if (!isSkipButtonHeld)
        {
            correctCounter++;

            currentWordIndex++;

            DisplayNextWord();
        }
    }

    public void SkipButton()
    {
        if (!isCorrectButtonHeld)
        {
            skipCounter++;

            currentWordIndex++;

            DisplayNextWord();
        }
    }
    public int GetCorrectWordCounter()
    {
        return correctCounter;
    }

    public int GetSkipWordCounter()
    {
        return skipCounter;
    }

    public string GetCurrentPlayerName()
    {
        if (currentIndexPlayer < 0 || currentIndexPlayer >= currentSessionPlayerList.Count)
        {
            currentIndexPlayer = 0;
        }

        return currentSessionPlayerList[currentIndexPlayer];
    }

    public void CurrentIndexPlayerIncrement()
    {
        if(currentIndexPlayer == currentSessionPlayerList.Count - 1)
        {
            currentIndexPlayer = 0;
        }
        else
        {
            currentIndexPlayer++;
        }

    }

    public bool IsGameOver()
    {
        return timerMechanism.GetGameOver();
    }
}

