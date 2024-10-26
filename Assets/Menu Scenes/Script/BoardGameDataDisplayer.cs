using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoardGameDataDisplayer : MonoBehaviour
{
    [SerializeField] Image boardgameIcon;
    [SerializeField] TextMeshProUGUI boardgameName;
    [SerializeField] TextMeshProUGUI duration;
    [SerializeField] TextMeshProUGUI playerRequirement;
    public void Display(BoardGameData data)
    {
        boardgameIcon.sprite = data.boardgameIcon;
        boardgameName.text = data.boardgameName;
        duration.text = data.duration;
        playerRequirement.text = data.playerRequirement;
    }
}
