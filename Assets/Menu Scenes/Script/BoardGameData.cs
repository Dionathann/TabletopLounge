using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[System.Serializable]
[CreateAssetMenu(fileName = "BoardGameData", menuName = "Board Game Data")]
public class BoardGameData : ScriptableObject
{
    public Sprite boardgameIcon;
    public string boardgameName;
    public string duration;
    public string playerRequirement;
    public string nameScene;

    [TextArea(2, 4)]
    public string description;

}
