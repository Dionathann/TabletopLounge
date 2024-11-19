using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TheAgentRoleCardFlipper : MonoBehaviour
{
    private Image Card;
    public TheAgentRoleDisplay agentRoleDisplay;
    public Sprite frontFaceCard;
    public TextMeshProUGUI locationText;
    //private Sprite faceSprite, backSprite;

    private bool coroutineAllowed, facedUp;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.transform.rotation = ;
        Card = GetComponent<Image>();
        Card.sprite = agentRoleDisplay.backCard;
        coroutineAllowed = true;
        facedUp = false;
    }

    public void Toggle()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(RotateCard());
        }
    }

    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;

        if (!facedUp)
        {
            for (float i = 180f; i >= 0f; i -= 10f) 
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    agentRoleDisplay.GetPlayerRole(agentRoleDisplay.GetCurrentIndexPlayer());
                    agentRoleDisplay.nextButton.interactable = true;
                    Card.sprite = frontFaceCard;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        else if (facedUp)
        {
            for (float i = 0f; i <= 180f; i += 10f)
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 90f)
                {
                    agentRoleDisplay.DisableMiddleIcon();

                    agentRoleDisplay.locationHolder.SetActive(false);
                    agentRoleDisplay.agentImageCard.SetActive(false);
                    agentRoleDisplay.imageLocationName.gameObject.SetActive(false);

                    Card.sprite = agentRoleDisplay.backCard;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineAllowed = true;

        facedUp = !facedUp;
    }

    public void ForceFaceDownCard()
    {
        locationText.gameObject.SetActive(false);
        agentRoleDisplay.DisableMiddleIcon();
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        facedUp = false;
    }
}
