using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameHolder : MonoBehaviour
{
    [SerializeField] TotalPlayerHolder totalPlayerHolder;
    [SerializeField] WarningDisplay warningDisplay;
    public List<string> playerNameList = new List<string>();


    [SerializeField] TMP_InputField inputField;

    public Transform contentHolder;
    public GameObject nameBox;
    private List<GameObject> instantiatedNameObjects = new List<GameObject>();

    [SerializeField] TextMeshProUGUI totalPlayerDisplay;

    [ContextMenu("Use Previous Name")]
    public void UsePreviousName()
    {
        //playerNameList = new List<string>(PlayerNameData.playerNameList);

        List<string> namesToAdd = new List<string>(PlayerNameData.playerNameList);

        PlayerNameData.playerNameList.Clear();

        foreach (string name in namesToAdd)
        {
            Debug.Log(namesToAdd.Count);
            if (!playerNameList.Contains(name))
            {
                InstantiateNameInput(name);

                totalPlayerHolder.PlayerIncrement();

                DisplayPlayerCounter();
            }
        }

    }

    public void DontUsePreviousName()
    {
        PlayerNameData.playerNameList.Clear();
    }

    public void ConfirmAddName()
    {
        //int playernow = totalPlayerHolder.GetPlayerCount();

        if(string.IsNullOrEmpty(inputField.text))
        {
            warningDisplay.SetWarningMessage("Input Can't be Empty");
            return;
        }

        string inputFieldText = inputField.text;

        if(playerNameList.Count < totalPlayerHolder.GetMaxPlayer())
        {
            if (!string.IsNullOrEmpty(inputFieldText))
            {
                if (playerNameList.Contains(inputFieldText))
                {
                    warningDisplay.SetWarningMessage("Name Already Exist");
                    Debug.Log("Name Already Exist");
                    return;
                }
                else
                {
                    PlayerNameData.playerNameList.Add(inputFieldText);

                    InstantiateNameInput(inputFieldText);

                    totalPlayerHolder.PlayerIncrement();
                }
            }
        }
        
        inputField.text = string.Empty;

        DisplayPlayerCounter();


    }

    public void InstantiateNameInput(string name)
    {
        var NewGameObject = Instantiate(nameBox, contentHolder);

        TextMeshProUGUI textInside = NewGameObject.GetComponentInChildren<TextMeshProUGUI>();

        if (textInside != null)
        {
            textInside.text = name;
        }

        Button deleteButton = NewGameObject.GetComponentInChildren<Button>();

        if (deleteButton != null)
        {
            GameObject ObjectToDelete = NewGameObject;

            AddString(name);

            deleteButton.onClick.AddListener(() => RemoveName(ObjectToDelete));

            deleteButton.onClick.AddListener(() => RemoveNameFromList(name));

            deleteButton.onClick.AddListener(() => totalPlayerHolder.PlayerDecrement());

            deleteButton.onClick.AddListener(() => DisplayPlayerCounter());
        }
    }



    public void DisplayPlayerCounter()
    {
        totalPlayerDisplay.text = totalPlayerHolder.GetPlayerCount().ToString();
    }

    private void RemoveNameFromList(string name)
    {
        playerNameList.Remove(name);
        PlayerNameData.playerNameList.Remove(name);
    }

    private void RemoveName(GameObject objectToDelete)
    {
        instantiatedNameObjects.Remove(objectToDelete);

        Destroy(objectToDelete);
    }

    private void AddString(string name)
    {
        playerNameList.Add(name);
    }

}
