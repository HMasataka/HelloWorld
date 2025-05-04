
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StopButton : UdonSharpBehaviour
{
    private Timer timer;

    void Start()
    {
        timer = GetComponentInParent<Timer>();
        if (!timer)
        {
            Debug.LogError("Timer component not found on this GameObject.");
            return;
        }
    }

    public override void Interact()
    {
        if (!timer) return;
        timer.Stop();
    }
}
