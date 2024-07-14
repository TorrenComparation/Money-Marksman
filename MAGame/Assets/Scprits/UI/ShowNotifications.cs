using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowNotifications : MonoBehaviour
{
    [SerializeField] private Animator _notificationAnimator;
    [SerializeField] private TextMeshProUGUI _notificationText;

    public void NotEnoughtMoney()
    {
        StartCoroutine(Delay());
        _notificationText.text = "Not Enought Money";
    }
    private IEnumerator Delay()
    {
        _notificationAnimator.SetBool("GetNotification", true);
        yield return new WaitForSeconds(1f);
        _notificationAnimator.SetBool("GetNotification", false);

    }
}
