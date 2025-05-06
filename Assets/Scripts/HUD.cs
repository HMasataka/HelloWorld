using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class HUD : UdonSharpBehaviour
{
    [SerializeField]
    Image ProgressBar;

    [SerializeField]
    GameObject message;

    private float WaitTime = 10.0f;
    private float ProgressTime = 0f;

    private void Update()
    {
        if (!Utilities.IsValid(Networking.LocalPlayer)) { return; }

        this.transform.position = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position;
        this.transform.rotation = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation;

        if (ProgressTime >= WaitTime)
        {
            message.SetActive(false);
            ProgressBar.fillAmount = 0.0f;
            return;
        }

        ProgressTime += Time.deltaTime;
        ProgressBar.fillAmount = 1.0f - (ProgressTime / WaitTime);
    }
}