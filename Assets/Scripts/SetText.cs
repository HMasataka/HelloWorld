
using System;
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using VRC.SDKBase;
using VRC.Udon;
using TMPro;

public class SetText : UdonSharpBehaviour
{
    private TMP_Text text;
    void Start()
    {
        text = GameObject.Find("Content").GetComponent<TMP_Text>();
        text.text = "";
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        text.text = "Hello, " + player.displayName + "! \r\n";
    }
}
