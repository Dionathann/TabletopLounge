using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NameHolder : MonoBehaviour
{
    [SerializeField] TotalPlayerHolder totalPlayerHolder;

    public List<string> playerNameList = new List<string>();

    [SerializeField] TextMeshProUGUI displayName;

    [SerializeField] TMP_InputField inputField;

    public Transform contentHolder;
    public GameObject nameBox;
    private List<GameObject> instantiatedNameObjects = new List<GameObject>();

    public void ConfirmAddName()
    {
        int playernow = totalPlayerHolder.GetPlayerCount();

        string inputFieldText = inputField.text;
        if (!string.IsNullOrEmpty(inputFieldText))
        {
            if (playerNameList.Contains(inputFieldText))
            {
                Debug.Log("Name Already Exist");
                return;
            }
            else
            {
                InstantiateNameInput(inputFieldText);

                Debug.Log("Name Added : " + inputFieldText);

            }
        }
        inputField.text = string.Empty;
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
        }
    }

    private void RemoveNameFromList(string name)
    {
        playerNameList.Remove(name);
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
