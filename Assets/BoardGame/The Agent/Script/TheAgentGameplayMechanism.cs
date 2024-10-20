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

    public void DisplayLocation()
    {

        agentRoleMechanism.GetShuffledLocation();

        for (int i = 0; i < agentRoleMechanism.GetMaxLocation(); i++)
        {
            GameObject newImage = Instantiate(imagePrefab, gridTransform);

            newImage.GetComponent<Image>().sprite = agentRoleMechanism.GetShuffledLocation()[i];
        }
    }
}
