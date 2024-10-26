using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField] GameObject mainMenuPanel;
    [SerializeField] GameObject boardGameSelectionPanel;
    [SerializeField] BoardGameSelection boardGameSelection;
    public void PlayButton()
    {
        mainMenuPanel.SetActive(false);
        boardGameSelectionPanel.SetActive(true);
        boardGameSelection.DisplayBoardGame();
    }

    public void AboutButton()
    {
        Debug.Log("About Button");
    }

    public void HelpButton()
    {
        Debug.Log("Help Button");
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}
