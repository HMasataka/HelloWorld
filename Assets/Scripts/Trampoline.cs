using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Trampoline : UdonSharpBehaviour
{
    public override void OnPlayerTriggerEnter(VRCPlayerApi player)
    {
        if (!Utilities.IsValid(Networking.LocalPlayer)) { return; }
        if (!player.isLocal) { return; }

        Vector3 InVelocity = Networking.LocalPlayer.GetVelocity();
        Vector3 localInVelocity = Quaternion.Inverse(this.transform.rotation) * InVelocity;
        Vector3 localOutVelocity = new Vector3(localInVelocity.x, -localInVelocity.y, localInVelocity.z);
        Vector3 OutVelocity = this.transform.rotation * localOutVelocity;

        Networking.LocalPlayer.SetVelocity(OutVelocity);
    }
}