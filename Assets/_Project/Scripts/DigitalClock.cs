using System;
using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text secondsText;
    [SerializeField] private TMP_Text dateText;

    private int lastSecond = -1;

    private void Update()
    {
        DateTime now = DateTime.Now;
        if (now.Second == lastSecond)
        {
            return;
        }

        lastSecond = now.Second;
        timeText.text = now.ToString("HH:mm");
        secondsText.text = now.ToString("ss");
        dateText.text = now.ToString("ddd d MMM").ToUpper();
    }
}
