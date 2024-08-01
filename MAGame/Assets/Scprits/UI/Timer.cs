using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Animator animatorPanel;
    [SerializeField] private GameObject counting;
    [SerializeField, Range(0, 60)] private int minute;
    [SerializeField, Range(0, 59)] private int second;

    private const int MaxSeconds = 59;

    private void OnValidate()
    {
        if (timerText == null)
            Debug.LogWarning("Timer Text is not assigned.", this);
        if (animatorPanel == null)
            Debug.LogWarning("Animator Panel is not assigned.", this);
        if (counting == null)
            Debug.LogWarning("Counting GameObject is not assigned.", this);
    }

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
            second = MaxSeconds;
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
        timerText.text = $"{minute:00}:{second:00}";
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
