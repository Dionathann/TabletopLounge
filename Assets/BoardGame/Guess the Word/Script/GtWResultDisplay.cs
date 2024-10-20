using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GtWResultDisplay : MonoBehaviour
{
    [SerializeField] GtWGameplayMechanism gameplayMechanism;

    [SerializeField] TextMeshProUGUI currentPlayer;    
    
    [SerializeField] TextMeshProUGUI correctCounterText;
    [SerializeField] TextMeshProUGUI skipCounterText;

    [Header("UI Reference")]
    [SerializeField] GameObject gameplayScreen;
    [SerializeField] GameObject resultScreen;
    private void Update()
    {
        if (gameplayMechanism.IsGameOver())
        {
            DisplayResult();
        }
    }

    [ContextMenu("Display Result")]
    public void DisplayResult()
    {
        gameplayScreen.SetActive(false);
        
        resultScreen.SetActive(true);

        int wordCounter = gameplayMechanism.GetCorrectWordCounter();

        int skipCounter = gameplayMechanism.GetSkipWordCounter();

        correctCounterText.text = "Correct Word : " +wordCounter.ToString();

        skipCounterText.text = "Skip Word : " + skipCounter.ToString();

        currentPlayer.text = gameplayMechanism.GetCurrentPlayerName() + " , Your Result is";
    }

}
