using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordMechanism : MonoBehaviour
{
    [SerializeField] WordData wordData;

    [SerializeField] TextMeshProUGUI wordTextEnglish;
    [SerializeField] TextMeshProUGUI wordTextIndonesia;

    private int currentIndex;

    [ContextMenu("Show the Word")]
    private void GetWord()
    {
        RandomizeWordIndex();
        DisplayWord();
    }

    private void RandomizeWordIndex()
    {
        currentIndex = -1;

        currentIndex = Random.Range(0, wordData.wordsListIndonesia.Count);

        Debug.Log(currentIndex);
    }
    private string GetWordEnglish()
    {
        return wordData.wordsListEnglish[currentIndex];
    }

    private string GetWordIndonesia()
    {
        return wordData.wordsListIndonesia[currentIndex];
    }


    private void DisplayWord()
    {
        wordTextEnglish.text = GetWordEnglish();
        wordTextIndonesia.text = GetWordIndonesia();
    }
}
