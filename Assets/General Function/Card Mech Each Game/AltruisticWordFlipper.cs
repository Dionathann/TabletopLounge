using System.Collections;
using UnityEngine;

public class AltruisticWordFlipper : MonoBehaviour
{
    private bool coroutineAllowed, facedUp;

    [SerializeField] GameObject textIndonesia;
    [SerializeField] GameObject textEnglish;
    [SerializeField] GameObject dividerText;
    private Coroutine cardFlipCoroutine;

    void Start()
    {
        coroutineAllowed = true;
        facedUp = false;
        HoldCard(false);
    }

    public void OnRelease()
    {
        if (cardFlipCoroutine != null)
        {
            StopCoroutine(cardFlipCoroutine);
        }
        cardFlipCoroutine = StartCoroutine(RotateCard(false));
    }

    public void OnHold()
    {
        if (coroutineAllowed)
        {
            cardFlipCoroutine = StartCoroutine(RotateCard(true)); 
        }
    }

    private IEnumerator RotateCard(bool flipForward)
    {
        coroutineAllowed = false;
        float startAngle = flipForward ? 180f : 0f;
        float endAngle = flipForward ? 0f : 180f;

        for (float i = startAngle; flipForward ? (i >= endAngle) : (i <= endAngle); i += flipForward ? -10f : 10f)
        {
            transform.rotation = Quaternion.Euler(0f, i, 0f);
            if (i == 90f)
            {
                HoldCard(flipForward);
            }
            yield return new WaitForSeconds(0.01f);
        }

        facedUp = flipForward; 
        coroutineAllowed = true;
    }

    private void HoldCard(bool show)
    {
        textIndonesia.SetActive(show);
        textEnglish.SetActive(show);
        dividerText.SetActive(show);
    }

    public void ForceFaceDownCard()
    {
        HoldCard(false);
        transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        facedUp = false;
    }
}
