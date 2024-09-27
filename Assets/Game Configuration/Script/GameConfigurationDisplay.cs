using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameConfigurationDisplay : MonoBehaviour
{
    [SerializeField] TotalPlayerHolder totalPlayerHolder;

    [SerializeField] TMP_Text playerCountDisplay;

    private void Start()
    {
        DisplayTotalPlayer();
    }

    public void DisplayTotalPlayer()
    {
        int playerCount = totalPlayerHolder.GetPlayerCount();

        playerCountDisplay.text = playerCount.ToString();
    }

}
