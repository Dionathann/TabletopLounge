using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarningDisplay : MonoBehaviour
{
    [SerializeField] GameObject warningPanel;
    [SerializeField] TextMeshProUGUI warningMessage;
    public float fadeOutTime = 2.0f;
    public float displayTime = 1.0f;

    private CanvasGroup canvasGroup;
    private void Start()
    {
        if (canvasGroup == null)
        {
            canvasGroup = warningPanel.AddComponent<CanvasGroup>();
        }
        canvasGroup.alpha = 0;
        warningPanel.SetActive(false);
    }

    public void SetWarningMessage(string message)
    {
        warningMessage.text = message;
        StopAllCoroutines();
        StartCoroutine(FadeErrorMessage());
    }

    private IEnumerator FadeErrorMessage()
    {
        warningPanel.SetActive(true);
        canvasGroup.alpha = 1;

        yield return new WaitForSeconds(displayTime);

        float elapsedTime = 0;
        while (elapsedTime < fadeOutTime)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1, 0, elapsedTime / fadeOutTime);
            yield return null;
        }

        canvasGroup.alpha = 0;
        warningPanel.SetActive(false);
    }
}
