using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordMechanism : MonoBehaviour
{
    [SerializeField] WordData wordData;


    private int currentIndex;

    [ContextMenu("Show the Word")]
    public void GetWord()
    {
        RandomizeWordIndex();
        //DisplayWord();
    }

    private void RandomizeWordIndex()
    {
        currentIndex = -1;

        currentIndex = Random.Range(0, wordData.wordsListIndonesia.Count);
    }

    public string GetWordEnglish()
    {
        return wordData.wordsListEnglish[currentIndex];
    }

    public string GetWordIndonesia()
    {
        return wordData.wordsListIndonesia[currentIndex];
    }

    /*private void DisplayWord()
    {
        wordTextEnglish.text = GetWordEnglish();
        wordTextIndonesia.text = GetWordIndonesia();
    }*/

    public int GetCurrentWordIndex()
    {
        return currentIndex;
    }
}
