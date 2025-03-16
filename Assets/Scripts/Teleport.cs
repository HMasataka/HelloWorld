
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Teleport : UdonSharpBehaviour
{
    [SerializeField] private GameObject teleportPointTo;
    public override void Interact()
    {
        Networking.LocalPlayer.TeleportTo(teleportPointTo.transform.position, teleportPointTo.transform.rotation);
    }
}
