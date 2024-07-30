using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Animator animatorPanel;
    [SerializeField] private GameObject counting;
    [SerializeField, Range(0, 59)] private int minute;
    [SerializeField, Range(0, 59)] private int second;

    private const int maxSeconds = 59;

    private void OnEnable()
    {
        StartCoroutine(StartMinigame());
    }

    private void UpdateTimer()
    {
        if (second == 0)
        {
            if (minute == 0)
            {
                EndMinigame();
                return;
            }
            minute--;
            second = maxSeconds;
        }
        else
        {
            second--;
        }

        UpdateTimerText();
    }

    private void EndMinigame()
    {
        animatorPanel.SetBool("HasStarted", false);
        CancelInvoke(nameof(UpdateTimer));
    }

    private void UpdateTimerText()
    {
        string minutesText = minute.ToString("00");
        string secondsText = second.ToString("00");
        timerText.text = $"{minutesText}:{secondsText}";
    }

    private IEnumerator StartMinigame()
    {
        UpdateTimerText();
        counting.SetActive(true);
        animatorPanel.SetBool("HasStarted", true);
        yield return new WaitForSeconds(3f);
        counting.SetActive(false);
        InvokeRepeating(nameof(UpdateTimer), 1, 1);
    }
}
