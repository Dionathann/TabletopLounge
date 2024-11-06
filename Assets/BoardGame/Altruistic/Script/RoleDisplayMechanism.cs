using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static AltruisticRoleMechanism;

public class RoleDisplayMechanism : MonoBehaviour
{
    private int currentIndexPlayer;
    [Header("Script Reference")]
    [SerializeField] AltruisticRoleMechanism altruisticRoleMechanism;
    [SerializeField] NameHolder nameHolder;
    [SerializeField] WarningDisplay warningDisplay;
    [SerializeField] Card card;
    [SerializeField] WordMechanism wordMechanism;

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
    public Button nextButton;
    [SerializeField] TMP_Dropdown gameModeDropdown;
    [SerializeField] GameObject confirmationPanel;
    [SerializeField] TextMeshProUGUI confirmationPlayerName;
    [SerializeField] GameObject confirmationScreen;

    [SerializeField] GameObject wordBoxPanel;
    [SerializeField] TextMeshProUGUI altruisticWordIndo;
    [SerializeField] TextMeshProUGUI altruisticWordEnglish;

    [SerializeField] GameObject customMasterNameDisplayer;
    [SerializeField] GameObject playerNameBox;
    [SerializeField] Transform customMasterNameHolder;

    [Header("FlipCard Variable")]
    private Quaternion originalRotation;
    private Quaternion flippedRotation;
    private bool coroutineAllowed, facedUp;
    [SerializeField] RectTransform imageRectTransform;

    private bool gameModeCheck;

    private List<GameObject> masterOptions = new List<GameObject>();
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

        card.ForceFaceDownCard();

        wordMechanism.GetWord();

        currentIndexPlayer = 0;
        
        RoleCardImage.sprite = backCard;
        
        nextButton.interactable = false;

        if (gameModeDropdown.value == 3)
        {
            customMasterNameDisplayer.SetActive(true);
        }
        else
        {
            nameText.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;

            ShowPlayerConfirmation();
        }

        //nameText.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;

    }
/*
    private void Start()
    {
        nameText.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;

        ShowPlayerConfirmation();
    }*/

    public void ShowPlayerConfirmation()
    {
        confirmationPlayerName.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;

        confirmationPanel.SetActive(true);
    }

    public void HidePlayerConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    [ContextMenu("Next Player")]
    public void NextPlayerButton()
    {
        if(wordBoxPanel == true)
        {
            wordBoxPanel.SetActive(false);
        }

        if(currentIndexPlayer >= altruisticRoleMechanism.characters.Count - 1)
        {
            Debug.Log("Role Finish");
            RoleDisplayAltruisticPrefab.SetActive(false);
            confirmationScreen.SetActive(true);
            return;
        }

        currentIndexPlayer++;

        Debug.Log("show Role");

        card.ForceFaceDownCard();

        nextButton.interactable = false;

        RoleCardImage.sprite = backCard;

        nameText.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;

        ShowPlayerConfirmation();

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
                warningDisplay.SetWarningMessage("Three Player Mode Cant Exceuted, Total Player Must 3");
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
                warningDisplay.SetWarningMessage("Additional Role Mode Cant Exceuted, Player Must More Than 5");
                Debug.Log("Additional Mode Cant Exceuted");
                return;
            }
        }
        if (gameModeValue == 3)
        {
            if (nameHolder.playerNameList.Count >= 4)
            {
                altruisticRoleMechanism.characters.Clear();

                MasterChooserPLayerName();

                Debug.Log("Normal Mode");
            }
            else
            {
                warningDisplay.SetWarningMessage("Master Pick Up Cant Exceuted, Player Must More than 3");
                Debug.Log("Normal Mode Cant Exceuted");
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
            ShowWordForAltruistic();

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
            ShowAltruistic();
            RoleCardImage.sprite = supportCardRole;
        }
    }

    private void ShowAltruistic()
    {
        wordBoxPanel.SetActive(true);

        altruisticWordIndo.text = "Altruistic is";
        for(int i = 0; i < altruisticRoleMechanism.playerName.Count; i++)
        {
            if (altruisticRoleMechanism.characters[i].isAltruistic)
            {
                altruisticWordEnglish.text = altruisticRoleMechanism.characters[i].name;
            }
        }
    }


    private void ShowWordForAltruistic()
    {
        wordBoxPanel.SetActive(true);

        string indonesiaWord = wordMechanism.GetWordIndonesia();
        string englishWord = wordMechanism.GetWordEnglish();

        altruisticWordIndo.text = indonesiaWord;
        altruisticWordEnglish.text = englishWord;

    }

    public void MasterChooserPLayerName()
    {
        foreach (GameObject obj in masterOptions)
        {
            Destroy(obj);
        }

        masterOptions.Clear();
        

        for (int i = 0; i < altruisticRoleMechanism.playerName.Count; i++)
        {
            DisplayName(altruisticRoleMechanism.playerName[i], i);
        }
    }

    private void DisplayName(string name, int index)
    {
        var newGameObject = Instantiate(playerNameBox, customMasterNameHolder);

        masterOptions.Add(newGameObject);

        TextMeshProUGUI textInside = newGameObject.GetComponentInChildren<TextMeshProUGUI>();

        if (textInside != null)
        {
            textInside.text = name;
        }

        Button button = newGameObject.GetComponentInChildren<Button>();

        if (button != null)
        {
            button.onClick.AddListener(() => OnButtonClick(index));
        }

        GameObjectIndex indexComponent = newGameObject.AddComponent<GameObjectIndex>();

        indexComponent.index = index;
    }

    public void OnButtonClick(int index)
    {
        Debug.Log("Player " + index + " clicked");

        SetMaster(index);

        altruisticRoleMechanism.MasterPickUp(index);

        customMasterNameDisplayer.SetActive(false);

        nameText.text = altruisticRoleMechanism.characters[currentIndexPlayer].name;

        ShowPlayerConfirmation();
    }

    private void SetMaster(int newIndex)
    {
        altruisticRoleMechanism.characters.Add(new AltruisticPlayerData(altruisticRoleMechanism.playerName[newIndex], true, false, false, false));
    }

    public int GetCurrentPlayerIndex()
    {
        return currentIndexPlayer;
    }
}
