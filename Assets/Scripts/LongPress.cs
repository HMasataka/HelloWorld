
using UdonSharp;
using UnityEngine;
using VRC.Udon.Common;
using VRC.SDKBase;
using VRC.Udon;

[AddComponentMenu("Boostia/UI/LongPress")]
[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class LongPress : UdonSharpBehaviour
{

#pragma warning disable IDE0044
    [SerializeField, Range(0.1f, 10f)]
    [Tooltip("The threshold time to trigger the event.")]
    private float threshold = 1f;

    [SerializeField]
    [Tooltip("The object which contains long pressed event")]
    private UdonSharpBehaviour eventTrigger;

    [SerializeField]
    [Tooltip("The event name when long-pressed.")]
    private string eventNameOnLongPress = "OnLongPress";

    [SerializeField]
    [Tooltip("The event name when released before the threshold.")]
    private string eventNameOnRelease = "OnRelease";
#pragma warning restore IDE0044

    private bool isPressing = false;

    private float pressStartTime = 0f;

    public float Progress => Mathf.Clamp01(Duration / Threshold);

    public bool IsPressing => isPressing;

    public float Threshold => threshold;

    private float Duration => Time.time - pressStartTime;

    public override void Interact()
    {
        isPressing = true;
        pressStartTime = Time.time;
        Debug.Log($"Pressing started at {pressStartTime}");
        SendCustomEventDelayedFrames(nameof(OnPressing), 0);
    }

    public override void InputUse(bool value, UdonInputEventArgs args)
    {
        Debug.Log($"InputUse: {value}");
        if (!value && isPressing)
        {
            isPressing = false;
            if (Duration < Threshold)
            {
                eventTrigger.SendCustomEvent(eventNameOnRelease);
            }
        }
    }

    public void OnPressing()
    {
        Debug.Log($"Pressing at {Duration}");
        if (!isPressing) return;

        if (Duration >= Threshold)
        {
            isPressing = false;
            eventTrigger.SendCustomEvent(eventNameOnLongPress);
        }
        else
        {
            SendCustomEventDelayedFrames(nameof(OnPressing), 1);
        }
    }

    public void OnLongPress()
    {
        Debug.Log("Long Press Event Triggered");
    }

    public void OnRelease()
    {
        Debug.Log("Release Event Triggered");
    }

    private void Start()
    {
        if (eventTrigger == null) eventTrigger = this;
    }
}
