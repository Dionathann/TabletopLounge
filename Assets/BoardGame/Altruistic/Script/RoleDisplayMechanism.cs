using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleDisplayMechanism : MonoBehaviour
{
    private int currentIndexPlayer;
    [Header("Script Reference")]
    [SerializeField] AltruisticRoleMechanism altruisticRoleMechanism;
    [SerializeField] NameHolder nameHolder;
    [SerializeField] WarningDisplay warningDisplay;
    [SerializeField] Card card;
    [Header("Image Asset")]
    public Sprite backCard;
    [SerializeField] Sprite masterCardRole;
    [SerializeField] Sprite altruisticCardRole;
    [SerializeField] Sprite ordinaryCardRole;
    [SerializeField] Sprite supportCardRole;

    [Header("UI References")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image RoleCardImage;
    [SerializeField] GameObject GameConfigurationCanvasPrefab;
    [SerializeField] GameObject RoleDisplayAltruisticPrefab;
    [SerializeField] Button nextButton;
    [SerializeField] TMP_Dropdown gameModeDropdown;
    [SerializeField] GameObject confirmationPanel;
    [SerializeField] TextMeshProUGUI confirmationPlayerName;

    [Header("FlipCard Variable")]
    private Quaternion originalRotation;
    private Quaternion flippedRotation;
    private bool coroutineAllowed, facedUp;
    [SerializeField] RectTransform imageRectTransform;

    private bool gameModeCheck;

    public void Inizialize()
    {
        altruisticRoleMechanism.PassListName();

        bool isPassed = altruisticRoleMechanism.PlayerCheck();
        if (isPassed == false)
        {
            warningDisplay.SetWarningMessage("Total Player and Listed Player Doesnt Match!");
            return;
        }
        Debug.Log("Passed!");
        ///////////////////////////////////////////////////////////////////////////////

        CheckPlayerForGameMode();

        if(gameModeCheck == false)
        {
            return;
        }
        ///////////////////////////////////////////////////////////////////////////////
        

        GameConfigurationCanvasPrefab.SetActive(false);
        RoleDisplayAltruisticPrefab.SetActive(true);

        //////////////////////////////////////////////////////////////////////////////

        altruisticRoleMechanism.PassListName();

        //////////////////////////////////////////////////////////////////////////////

        currentIndexPlayer = 0;
        RoleCardImage.sprite = backCard;
        nextButton.interactable = false;
    }

    private void Start()
    {
        nameText.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;

        ShowPlayerConfirmation();
    }

    public void ShowPlayerConfirmation()
    {
        confirmationPlayerName.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;
    }

    public void HidePlayerConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    [ContextMenu("Next Player")]
    public void NextPlayerButton()
    {
        if(currentIndexPlayer >= altruisticRoleMechanism.characters.Count - 1)
        {
            Debug.Log("Role Finish");
            return;
        }

        currentIndexPlayer++;
        Debug.Log("show Role");
        card.ForceFaceDownCard();
        RoleCardImage.sprite = backCard;
        nameText.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;
        ShowPlayerConfirmation();
        confirmationPanel.SetActive(true);

    }


    [ContextMenu("Check Game Mode")]
    private void CheckPlayerForGameMode()
    {
        gameModeCheck = false;
        int gameModeValue = gameModeDropdown.value;

        if (gameModeValue == 0)
        {
            if(nameHolder.playerNameList.Count >= 4)
            {
                altruisticRoleMechanism.NormalMode();

                Debug.Log("Normal Mode");
            }
            else
            {
                warningDisplay.SetWarningMessage("Normal Mode Cant Exceuted, Player Must More than 3");
                Debug.Log("Normal Mode Cant Exceuted");
                return;
            }
        }
        if (gameModeValue == 1)
        {
            if(nameHolder.playerNameList.Count == 3)
            {
                altruisticRoleMechanism.ThreePlayerMode();
                Debug.Log("Three Player Mode");
            }
            else
            {
                warningDisplay.SetWarningMessage("Normal Mode Cant Exceuted, Total Player Must 3");
                Debug.Log("Three Player Mode Cant Exceuted");
                return;
            }
        }
        if (gameModeValue == 2)
        {
            if (nameHolder.playerNameList.Count >= 6)
            {
                altruisticRoleMechanism.AdditionalRole();
                Debug.Log("Additional Mode");
            }
            else
            {
                warningDisplay.SetWarningMessage("Normal Mode Cant Exceuted, Player Must More Than 5");
                Debug.Log("Additional Mode Cant Exceuted");
                return;
            }
        }
        gameModeCheck = true;
    }


    public void GetPlayerRole(int index)
    {
        if (altruisticRoleMechanism.characters[index].isMaster)
        {
            RoleCardImage.sprite = masterCardRole;
            Debug.Log(altruisticRoleMechanism.characters[index].name + " is Master");
        }
        if (altruisticRoleMechanism.characters[index].isAltruistic)
        {
            RoleCardImage.sprite = altruisticCardRole;
            Debug.Log(altruisticRoleMechanism.characters[index].name + " is Altruistic");
        }
        if (altruisticRoleMechanism.characters[index].isOrdinary)
        {
            RoleCardImage.sprite = ordinaryCardRole;
            Debug.Log(altruisticRoleMechanism.characters[index].name + " is Ordinary");
        }
        if (altruisticRoleMechanism.characters[index].isSupport)
        {
            RoleCardImage.sprite = supportCardRole;
        }
    }


    public int GetCurrentPlayerIndex()
    {
        return currentIndexPlayer;
    }
}
/*// Trigger flip and reveal role
    public void FlipCard()
    {
        if (!isRevealed)
        {
            imageRectTransform.rotation = flippedRotation; // Flip to reveal
            GetPlayerRole(currentIndexPlayer); // Show the role image
            isRevealed = true;
            nextButton.interactable = true; // Enable next button
        }
    }

    // Move to the next player
    public void ShowNextPlayer()
    {
        if (currentIndexPlayer < altruisticRoleMechanism.characters.Count - 1)
        {
            currentIndexPlayer++;
            ResetCard(); // Reset card to back
            isRevealed = false;
            nextButton.interactable = false; // Disable until next flip
        }
    }

    private void ResetCard()
    {
        imageRectTransform.rotation = originalRotation;
        RoleCardImage.sprite = backCard; // Show the back of the card
        nameText.text = ""; // Hide the name
    }*/
