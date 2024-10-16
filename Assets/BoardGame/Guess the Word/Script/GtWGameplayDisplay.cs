using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GtWGameplayDisplay : MonoBehaviour
{
    [SerializeField] GtWGameplayMechanism gtwMechanism;
    [SerializeField] TimerMechanism timerMechanism;
    [SerializeField] GtWWordData wordData;

    private int currentPlayerIndex;

    [Header("UI Reference")]
    [SerializeField] TextMeshProUGUI thisTurnPlayerName;
    [SerializeField] GameObject nameDisplayerPanel;
    [SerializeField] GameObject gameplayScreenPanel;

    [Header("Gameplay Screen")]
    [SerializeField] TextMeshProUGUI wordText;
    

    [ContextMenu("Display Name")]
    public void DisplayName()
    {
        var list = gtwMechanism.GetPlayerNameList();

        currentPlayerIndex = gtwMechanism.GetRandomIndexPlayer();

        Debug.Log(list[currentPlayerIndex]);

        thisTurnPlayerName.text = ("Now It's " + list[currentPlayerIndex] + "'s Turn");
    }

    [ContextMenu("Transition To Gameplay")]
    public void TransitionToGameplay()
    {
        gameplayScreenPanel.SetActive(true);

        nameDisplayerPanel.SetActive(false);

        timerMechanism.StartTimer();

        wordData.TestDefaultWord();

        string currenttext = RandomizeWord();

        wordText.text = currenttext;
    }

    private string RandomizeWord()
    {
        int i = Random.Range(0, wordData.wordList.Count);

        return wordData.wordList[i];
    }
}
