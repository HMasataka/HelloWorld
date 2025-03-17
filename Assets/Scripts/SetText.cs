
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
    void Start()
    {
        text.text = "";
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        text.text = "Hello, " + player.displayName + "! \r\n";
    }
}
