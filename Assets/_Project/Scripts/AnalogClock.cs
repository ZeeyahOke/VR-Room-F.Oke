using System;
using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    [SerializeField] private Transform hourHand;
    [SerializeField] private Transform minuteHand;
    [SerializeField] private Transform secondHand;
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    private Quaternion hourStart;
    private Quaternion minuteStart;
    private Quaternion secondStart;

    private void Awake()
    {
        hourStart = hourHand.localRotation;
        minuteStart = minuteHand.localRotation;
        secondStart = secondHand.localRotation;
    }

    private void Update()
    {
        DateTime now = DateTime.Now;
        float seconds = now.Second;
        float minutes = now.Minute + (seconds + now.Millisecond / 1000f) / 60f;
        float hours = now.Hour % 12 + minutes / 60f;

        SetHand(hourHand, hourStart, hours * 30f);
        SetHand(minuteHand, minuteStart, minutes * 6f);
        SetHand(secondHand, secondStart, seconds * 6f);
    }

    private void SetHand(Transform hand, Quaternion start, float angle)
    {
        hand.localRotation = start * Quaternion.AngleAxis(angle, rotationAxis);
    }
}
