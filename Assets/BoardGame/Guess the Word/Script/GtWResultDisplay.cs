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

    public static bool gameOverFlag;

    private void Update()
    {
        if (gameplayMechanism.IsGameOver() && !gameOverFlag)
        {
            DisplayResult();
        }
    }

    [ContextMenu("Display Result")]
    public void DisplayResult()
    {
        gameOverFlag = true;
        
        gameplayScreen.SetActive(false);
        
        resultScreen.SetActive(true);

        gameplayMechanism.SFXSound.PlayOneShot(gameplayMechanism.finishSound);

        int wordCounter = gameplayMechanism.GetCorrectWordCounter();

        int skipCounter = gameplayMechanism.GetSkipWordCounter();

        currentPlayer.text = gameplayMechanism.GetCurrentPlayerName() + " , Your Result is";

        correctCounterText.text = "Correct Word : " +wordCounter.ToString();

        skipCounterText.text = "Skip Word : " + skipCounter.ToString();

    }

}
