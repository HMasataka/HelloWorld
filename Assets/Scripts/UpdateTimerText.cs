
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using VRC.SDKBase;
using VRC.Udon;

[RequireComponent(typeof(TMP_Text))]
public class UpdateTimerText : UdonSharpBehaviour
{
    private Timer timer;
    private TMP_Text text;

    void Start()
    {
        timer = GetComponentInParent<Timer>();
        if (timer == null)
        {
            Debug.LogError("Timer component not found on this GameObject.");
        }

        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (!timer || !text) return;
        text.text = timer.DeltaTimeString();
    }
}
