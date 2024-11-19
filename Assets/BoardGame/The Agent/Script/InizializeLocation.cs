using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InizializeLocation : MonoBehaviour
{
    [SerializeField] TheAgentImageData agentImageData;

    public List<Sprite> locationList;
    public List<string> locationNames;

    public List<Sprite> shuffledLocationList;
    public List<string> shuffledLocationNames;

    [ContextMenu("Starting")]
    public void Start()
    {
        locationList = new List<Sprite>(agentImageData.imageLocation);
        locationNames = new List<string>(agentImageData.locationName);
    }

    [ContextMenu("Display Location")]
    public void RandomizerLocation()
    {
        shuffledLocationList.Clear();
        shuffledLocationNames.Clear();

        shuffledLocationList = new List<Sprite>(locationList);
        shuffledLocationNames = new List<string>(locationNames);

        for (int i = 0; i < shuffledLocationList.Count; i++)
        {
            Sprite tempImage = shuffledLocationList[i];
            string tempLocationName = shuffledLocationNames[i];

            int randomIndex = Random.Range(i, shuffledLocationList.Count);

            shuffledLocationList[i] = shuffledLocationList[randomIndex];
            shuffledLocationNames[i] = shuffledLocationNames[randomIndex];

            shuffledLocationList[randomIndex] = tempImage;
            shuffledLocationNames[randomIndex] = tempLocationName;
        }

    }
}
