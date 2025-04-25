using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class HUD : UdonSharpBehaviour
{
    //--------------------------------------- 
    private void Update()
    {
        if (!Utilities.IsValid(Networking.LocalPlayer)) { return; }

        this.transform.position = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).position;
        this.transform.rotation = Networking.LocalPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head).rotation;
    }
}