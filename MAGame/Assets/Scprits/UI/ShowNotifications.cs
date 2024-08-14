using System.Collections;
using TMPro;
using UnityEngine;

public class ShowNotifications : MonoBehaviour
{
    [SerializeField] private Animator notificationAnimator;
    [SerializeField] private TextMeshProUGUI notificationText;

    private Coroutine notificationCoroutine;

    public void GetNotification(string message)
    {
        if (notificationCoroutine != null)
        {
            StopCoroutine(notificationCoroutine);
        }

        notificationText.text = message;
        notificationCoroutine = StartCoroutine(ShowNotificationRoutine());
    }

    private IEnumerator ShowNotificationRoutine()
    {
        notificationAnimator.SetBool("GetNotification", true);
        yield return new WaitForSeconds(1f);
        notificationAnimator.SetBool("GetNotification", false);
    }
}
