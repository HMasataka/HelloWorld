using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Timer : UdonSharpBehaviour
{
    private bool IsTimerRunning = false;
    private float timer = 0f;
    void Update()
    {
        if (this.IsTimerRunning)
        {
            timer += Time.deltaTime;
        }
    }

    public bool IsRunning()
    {
        return this.IsTimerRunning;
    }

    public float DeltaTime()
    {
        return this.timer;
    }

    public string DeltaTimeString()
    {
        return this.timer.ToString("F2");
    }

    public void Run()
    {
        if (IsTimerRunning) return;
        IsTimerRunning = true;
    }

    public void Pause()
    {
        if (!IsTimerRunning) return;
        IsTimerRunning = false;
    }

    public void Stop()
    {
        if (!IsTimerRunning) return;
        this.timer = 0f;
        IsTimerRunning = false;
    }
}
