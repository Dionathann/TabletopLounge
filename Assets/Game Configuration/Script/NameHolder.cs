using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameHolder : MonoBehaviour
{
    [SerializeField] TotalPlayerHolder totalPlayerHolder;

    [SerializeField] List<string> playerNameList = new List<string>();

    [SerializeField] TextMeshProUGUI displayName;

    [SerializeField] TMP_InputField inputField;


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
                AddString(inputFieldText);

                Debug.Log("Name Added : " + inputFieldText);

                displayName.text = string.Join("\n", playerNameList);
            }
        }
        

        inputField.text = string.Empty;
    }

    private void AddString(string name)
    {
        playerNameList.Add(name);
    }
}
