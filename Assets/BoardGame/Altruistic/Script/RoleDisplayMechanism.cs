using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleDisplayMechanism : MonoBehaviour
{
    private int currentIndexPlayer;
    [SerializeField] AltruisticRoleMechanism altruisticRoleMechanism;
    [Header("Image Asset")]
    [SerializeField] Sprite backCard;
    [SerializeField] Sprite masterCardRole;
    [SerializeField] Sprite altruisticCardRole;
    [SerializeField] Sprite ordinaryCardRole;

    [Header("UI References")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image RoleCardImage;
    [Header("FlipCard Variable")]
    public float flipSpeed = 5f;  // Speed of the flip
    private bool isFlipping = false;
    private Quaternion originalRotation;
    private Quaternion flippedRotation;
    [SerializeField] RectTransform imageRectTransform;

    public void Inizialize()
    {
        currentIndexPlayer = 0;
        RoleCardImage.sprite = backCard;
    }

    [ContextMenu("Display Role")]
    public void DisplayRole()
    {
        if(currentIndexPlayer != altruisticRoleMechanism.characters.Count)
        {
            GetPlayerRole(currentIndexPlayer);
            currentIndexPlayer++;
        }   
    }
    
    private void Start()
    {
        originalRotation = imageRectTransform.rotation;

        flippedRotation = Quaternion.Euler(imageRectTransform.rotation.eulerAngles.x, imageRectTransform.rotation.eulerAngles.y + 180, imageRectTransform.rotation.eulerAngles.z);
    }

    public void FlipCard()
    {
        if (isFlipping)
        {
            isFlipping = false;
        }
        else
        {
            isFlipping= true;
        }
    }

    private void Update()
    {
        // Flip the image
        if (isFlipping)
        {
            // Rotate towards the flipped rotation
            imageRectTransform.rotation = Quaternion.Lerp(imageRectTransform.rotation, flippedRotation, Time.deltaTime * flipSpeed);
        }
        else
        {
            // Rotate back to the original rotation
            imageRectTransform.rotation = Quaternion.Lerp(imageRectTransform.rotation, originalRotation, Time.deltaTime * flipSpeed);
        }
    }


    private void GetPlayerRole(int index)
    {

        nameText.text = altruisticRoleMechanism.characters[index].name;

        if (altruisticRoleMechanism.characters[index].isMaster)
        {
            RoleCardImage.sprite = masterCardRole;
            Debug.Log(altruisticRoleMechanism.characters[index].name + " is Master");
        }
        if (altruisticRoleMechanism.characters[index].isAltruistic)
        {
            RoleCardImage.sprite = altruisticCardRole;
            Debug.Log(altruisticRoleMechanism.characters[index].name + " is Altruistic");
        }
        if (altruisticRoleMechanism.characters[index].isOrdinary)
        {
            RoleCardImage.sprite = ordinaryCardRole;
            Debug.Log(altruisticRoleMechanism.characters[index].name + " is Ordinary");
        }
    }
}
