using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TheAgentGameplayMechanism : MonoBehaviour
{
    [SerializeField] TheAgentRoleMechanism agentRoleMechanism;

    [SerializeField] InizializeLocation inizializeLocation;

    [SerializeField] GameObject imagePrefab;

    [SerializeField] Transform gridTransform;

    private List<GameObject> locationDisplayerList = new List<GameObject>();
    public void DisplayLocation()
    {
        foreach (GameObject obj in locationDisplayerList)
        {
            Destroy(obj);
        }

        locationDisplayerList.Clear();

        agentRoleMechanism.GetShuffledLocation();

        for (int i = 0; i < agentRoleMechanism.GetMaxLocation(); i++)
        {
            GameObject newImage = Instantiate(imagePrefab, gridTransform);

            newImage.GetComponent<Image>().sprite = agentRoleMechanism.GetShuffledLocation()[i];

            locationDisplayerList.Add(newImage);
        }
    }
}
