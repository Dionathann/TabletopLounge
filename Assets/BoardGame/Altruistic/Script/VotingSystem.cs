using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VotingSystem : MonoBehaviour
{
    [SerializeField] AltruisticRoleMechanism altruisticRoleMechanism;
    [SerializeField] GameObject nameDisplayer;

    [SerializeField] Transform contentHolder;
    public GameObject resultScreen;
    public GameObject voteScreen;

    [Header("Altrusistic Vote Screen")]
    [SerializeField] GameObject altruisticVotedScreen;
    [SerializeField] TextMeshProUGUI altruisticVotedText;
    [SerializeField] Image altruisticVotedImage;

    [Header("Not Altrusistic Vote Screen")]
    [SerializeField] GameObject notAltruisticVotedScreen;
    [SerializeField] TextMeshProUGUI notAltruisticVotedText;
    [SerializeField] Image notAltruisticVotedImage;

    [Header("Asset Icons")]
    public Sprite altruisticIcon;
    public Sprite ordinaryIcon;
    public Sprite supportIcon;

    private List<GameObject> voteDisplayers = new List<GameObject>();

    [ContextMenu("Initial Vote System")]
    public void InitialVoteSystem()
    {
        foreach(GameObject obj in voteDisplayers)
        {
            Destroy(obj);
        }

        voteDisplayers.Clear();

        if(altruisticRoleMechanism.GetDropDown().value == 3)
        {
            for (int i = 1; i < altruisticRoleMechanism.playerName.Count; i++)
            {
                DisplayName(altruisticRoleMechanism.characters[i].name, i);
            }
        }
        else
        {
            for (int i = 0; i < altruisticRoleMechanism.playerName.Count; i++)
            {
                if (!altruisticRoleMechanism.characters[i].isMaster)
                {
                    DisplayName(altruisticRoleMechanism.characters[i].name, i);
                }
            }
        }
        
    }

    private void DisplayName(string name, int index)
    {
        var newGameObject = Instantiate(nameDisplayer, contentHolder);

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

        voteDisplayers.Add(newGameObject);
    }

    public void OnButtonClick(int index)
    {
        Debug.Log("Player " + index + " clicked");

        voteScreen.SetActive(false);

        ShowEverything(index);

        Debug.Log("Test");
    }

    private void ShowEverything(int index)
    {
        Debug.Log("Show Everything");

        resultScreen.SetActive(true);

        bool altruistic = altruisticRoleMechanism.characters[index].isAltruistic;

        Debug.Log(altruistic);

        if (altruistic)
        {
            AltruisticVoted(index);
        }
        else
        {
            AltruisticNotVoted(index);
        }

    }

    public void AltruisticVoted(int i)
    {
        altruisticVotedScreen.SetActive(true);

        altruisticVotedText.text = "Yes, " + altruisticRoleMechanism.characters[i].name + " Is an Altruistic!";

        altruisticVotedImage.sprite = altruisticIcon;
    }

    private void AltruisticNotVoted(int i)
    {
        if (altruisticRoleMechanism.characters[i].isOrdinary)
        {
            notAltruisticVotedScreen.SetActive(true);

            notAltruisticVotedText.text = "No, " + altruisticRoleMechanism.characters[i].name + " Is an Ordinary!";

            notAltruisticVotedImage.sprite = ordinaryIcon;
        }
        if (altruisticRoleMechanism.characters[i].isSupport)
        {
            notAltruisticVotedScreen.SetActive(true);

            notAltruisticVotedText.text = "No, " + altruisticRoleMechanism.characters[i].name + " Is an Support!";

            notAltruisticVotedImage.sprite = supportIcon;
        }
    }

    public void ShowAltruistic()
    {
        for (int i = 0; i < altruisticRoleMechanism.playerName.Count; i++)
        {
            if (altruisticRoleMechanism.characters[i].isAltruistic)
            {
                altruisticVotedScreen.SetActive(true);

                altruisticVotedText.text = altruisticRoleMechanism.characters[i].name + " Is an Altruistic!";

                altruisticVotedImage.sprite = altruisticIcon;
            }
        }
    }

    public void BacktoMainMenu(string sceneName)
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}

[System.Serializable]
public class GameObjectIndex : MonoBehaviour
{
    public int index;
}
