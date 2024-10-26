using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IcognitoRoleCardFlipper : MonoBehaviour
{
    private Image Card;
    public IcognitoRoleDisplay icognitoRoleDisplay;
    //private Sprite faceSprite, backSprite;

    private bool coroutineAllowed, facedUp;

    // Start is called before the first frame update
    void Start()
    {
        Card = GetComponent<Image>();
        Card.sprite = icognitoRoleDisplay.backCard;
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
                    icognitoRoleDisplay.GetPlayerRole(icognitoRoleDisplay.GetCurrentPlayerIndex());
                    icognitoRoleDisplay.nextButton.interactable = true;
                    //rend.sprite = faceSprite;
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
                    Card.sprite = icognitoRoleDisplay.backCard;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineAllowed = true;

        facedUp = !facedUp;
    }

    public void ForceFaceDownCard()
    {
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        facedUp = false;
    }
}
