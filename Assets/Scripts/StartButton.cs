
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class StartButton : UdonSharpBehaviour
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
        Debug.Log("Button clicked!");

        if (!timer) return;
        timer.Run();
    }
}
