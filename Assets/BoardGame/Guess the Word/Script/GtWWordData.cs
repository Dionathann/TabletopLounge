using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Guess the Word Data", menuName = "Guess the Word/Make Word Data")]
public class GtWWordData : ScriptableObject
{
    public List<string> wordList = new List<string>();

    public void TestDefaultWord()
    {
        for(int i = 0; i < 5; i++)
        {
            wordList.Add(i.ToString());
        }    
    }

    private void AddWordtoList(string newWord)
    {
        wordList.Add(newWord);
    }
}
