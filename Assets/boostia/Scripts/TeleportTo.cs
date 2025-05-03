using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace boostia.common
{
    public class TeleportTo : UdonSharpBehaviour
    {
        [SerializeField] private GameObject teleportTo;
        public override void Interact()
        {
            Networking.LocalPlayer.TeleportTo(teleportTo.transform.position, teleportTo.transform.rotation);
        }
    }
}