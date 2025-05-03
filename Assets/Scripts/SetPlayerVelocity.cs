
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[RequireComponent(typeof(VRC_Pickup))]
public class SetPlayerVelocity : UdonSharpBehaviour
{
    [SerializeField] float Velocity;
    VRC_Pickup pickup;
    bool isDoubleJump = false;

    void Start()
    {
        pickup = GetComponent<VRC_Pickup>();
    }

    void Update()
    {
        if (!IsJumped())
        {
            isDoubleJump = false;
        }
    }

    public override void Interact()
    {
        pickup = GetComponent<VRC_Pickup>();
    }

    // AutoHoldがYesのPickupオブジェクトをつかんでいる時、トリガーを引いた際に呼ばれる関数
    public override void OnPickupUseDown()
    {
        if (isDoubleJump) return;
        if (IsJumped()) isDoubleJump = true;
        Impulse();
    }

    void Impulse()
    {
        Vector3 impulse = transform.forward * Velocity;
        Networking.LocalPlayer.SetVelocity(impulse);
    }

    bool IsJumped()
    {
        var player = pickup.currentPlayer;
        if (!Utilities.IsValid(player)) return false;

        return !player.IsPlayerGrounded();
    }
}