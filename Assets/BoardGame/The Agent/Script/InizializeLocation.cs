using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InizializeLocation : MonoBehaviour
{
    [SerializeField] TheAgentImageData agentImageData;

    public List<Sprite> locationList;

    public List<Sprite> shuffledLocationList;

    [ContextMenu("Starting")]
    public void Start()
    {


        locationList = new List<Sprite>(agentImageData.imageLocation);
    }

    [ContextMenu("Display Location")]
    public void RandomizerLocation()
    {
        shuffledLocationList.Clear();

        shuffledLocationList = new List<Sprite>(locationList);

        for (int i = 0; i < shuffledLocationList.Count; i++)
        {
            Sprite tempImage = shuffledLocationList[i];

            int randomIndex = Random.Range(i, shuffledLocationList.Count);

            shuffledLocationList[i] = shuffledLocationList[randomIndex];

            shuffledLocationList[randomIndex] = tempImage;
        }

    }
}
