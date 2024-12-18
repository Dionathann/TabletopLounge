using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GtWGameplayDisplay : MonoBehaviour
{
    [SerializeField] GtWGameplayMechanism gtwMechanism;
    [SerializeField] TotalPlayerHolder totalPlayerHolder;
    [SerializeField] WarningDisplay warningDisplay;
    [SerializeField] ScreenOrientation screenOrientation;
    private int currentPlayerIndex;

    [Header("UI Reference")]
    [SerializeField] TextMeshProUGUI thisTurnPlayerName;
    [SerializeField] GameObject gameConfigUI;
    [SerializeField] GameObject DisplayNameUI;

    public void ShowPlayerName()
    {
        if(totalPlayerHolder.GetPlayerCount() < 2)
        {
            warningDisplay.SetWarningMessage("Player Must More Than 2");
            return;
        }

        screenOrientation.ToggleOrientation();

        gameConfigUI.SetActive(false);

        DisplayNameUI.SetActive(true);

        DisplayName();

    }

    [ContextMenu("Display Name")]
    public void DisplayName()
    {
        var list = gtwMechanism.GetPlayerNameList();

        currentPlayerIndex = gtwMechanism.GetIndexPlayer();

        thisTurnPlayerName.text = (list[currentPlayerIndex] + " Will be the Guesser");
    }
}
