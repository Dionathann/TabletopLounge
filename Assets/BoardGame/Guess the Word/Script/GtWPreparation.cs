using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GtWPreparation : MonoBehaviour
{
    [SerializeField] GtWGameplayMechanism gameplayMechanism;

    [Header("UI Elements")]
    public GameObject countdownPanel;
    public TextMeshProUGUI mainText;

    public Coroutine countdownCoroutine;

    public AudioSource SFXAudioSource;
    public AudioClip countDownSound;
    public AudioClip playSound;

    public IEnumerator StartCountdown()
    {
        countdownPanel.SetActive(true);

        mainText.text = "Put Your Phone On Your Head";

        yield return new WaitForSeconds(4f);

        mainText.text = "Get Ready...";

        yield return new WaitForSeconds(3f);

        for (int i = 3; i > 0; i--)
        {
            SFXAudioSource.PlayOneShot(countDownSound);

            mainText.text = i.ToString();

            mainText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1f);
        }

        countdownPanel.SetActive(false);

        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }

        SFXAudioSource.PlayOneShot(playSound);
        gameplayMechanism.GameStart();
    }
}
