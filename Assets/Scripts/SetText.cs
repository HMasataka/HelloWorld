
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class SetText : UdonSharpBehaviour
{
    [SerializeField] private TMP_Text text;
    [UdonSynced, FieldChangeCallback(nameof(SyncedStr))] private string bSyncedStr;
    public string SyncedStr
    {
        set { bSyncedStr = value; TextChanged(); }
        get => bSyncedStr;
    }
    void Start()
    {
        text.text = "";
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (Networking.LocalPlayer.IsOwner(this.gameObject))
        {
            SyncedStr += "Hello, " + player.displayName + "! \r\n";
            RequestSerialization();
        }
    }


    private void TextChanged()
    {
        Debug.Log("HogeChanged");
        text.text = SyncedStr;
    }
}
