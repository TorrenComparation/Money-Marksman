using TMPro;
using System;
using UnityEngine;

public class ClockHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _hoursText;
    [SerializeField] private TextMeshProUGUI _minutesText;

    private float hours = 12;
    private float minutes;

    private byte minute = 59;
    private byte hour = 24;

   
    private void FixedUpdate()
    {
        if (minutes >= minute)
        {
            hours++;
            minutes -= minute;
            if (hours >= hour)
            {
                hours -= hour;
            }
        }
        else
        {
            minutes += Time.deltaTime;
        }

        if (Convert.ToInt32(minutes).ToString().Length < 2)
        {
            _minutesText.text = $":0{Convert.ToInt32(minutes)}";
        }
        else
        {
            _minutesText.text = $":{Convert.ToInt32(minutes)}";
        }

        if (Convert.ToInt32(hours).ToString().Length < 2)
        {
            _hoursText.text = $"0{Convert.ToInt32(hours)}";
        }
        else
        {
            _hoursText.text = $"{Convert.ToInt32(hours)}";
        }
    }


}
