using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Altruistic Word List", menuName = "Altruistic Word/WordList")]
public class WordData : ScriptableObject
{
    public List<string> wordsListIndonesia = new List<string>();
    public List<string> wordsListEnglish = new List<string>();

    private void DefaulStringInput()
    {

    }
}
