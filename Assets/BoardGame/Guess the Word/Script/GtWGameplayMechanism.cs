using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GtWGameplayMechanism : MonoBehaviour
{
    [SerializeField] NameHolder nameHolder;
    [SerializeField] TimerMechanism timerMechanism;
    [SerializeField] GtWWordData wordData;

    private int currentIndexPlayer;

    private int correctCounter;
    private int skipCounter;

    [Header("UI Reference")]
    [SerializeField] GameObject nameDisplayerPanel;
    [SerializeField] GameObject gameplayScreenPanel;
    [SerializeField] TextMeshProUGUI wordText;

    private List<string> tempList;

    private int currentWordIndex;
    public void GameStart()
    {
        wordData.TestDefaultWord();

        RandomizeTempList();

        correctCounter = 0;

        skipCounter = 0;

        gameplayScreenPanel.SetActive(true);

        nameDisplayerPanel.SetActive(false); 
        
        timerMechanism.StartTimer();

        GetNextWord(currentWordIndex);

        DisplayNextWord();
    }

    public List<string> GetPlayerNameList()
    {
        return nameHolder.playerNameList;
    }

    [ContextMenu("Test random")]
    public int GetRandomIndexPlayer()
    {
        currentIndexPlayer = Random.Range(0, nameHolder.playerNameList.Count);

        Debug.Log(currentIndexPlayer);

        return currentIndexPlayer;
    }


    public void RandomizeTempList()
    {
        tempList?.Clear();

        tempList = new List<string>(wordData.wordList);

        for(int i = 0; i < tempList.Count; i++)
        {
            string temp = tempList[i];

            int index = Random.Range(0, tempList.Count);

            tempList[i] = tempList[index];

            tempList[index] = temp;
        }
    }

    public string GetNextWord(int index)
    {
        return tempList[index];
    }

    public void DisplayNextWord()
    {
        wordText.text = tempList[currentWordIndex];
    }

    public void CorrectButton()
    {
        correctCounter++;

        currentWordIndex++;

        DisplayNextWord();
    }

    public void SkipButton()
    {
        skipCounter++;

        DisplayNextWord();

        currentWordIndex++;
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
        return nameHolder.playerNameList[currentIndexPlayer];
    }

    public bool IsGameOver()
    {
        return timerMechanism.GetGameOver();
    }
}

