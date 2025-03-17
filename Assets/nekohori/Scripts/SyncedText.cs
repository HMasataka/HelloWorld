using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;

[RequireComponent(typeof(InputField))]
[UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
public class SyncedText : UdonSharpBehaviour
{
    InputField m_InputField;
    [UdonSynced(UdonSyncMode.None)] string m_SyncedString;
    void Start()
    {
        m_InputField = GetComponent<InputField>();
    }
    public void ChangeOwner()
    {
        if (!Networking.LocalPlayer.IsOwner(this.gameObject))
        {
            Networking.SetOwner(Networking.LocalPlayer, this.gameObject);
        }
    }

    public void SyncText()
    {
        m_SyncedString = m_InputField.text;
        RequestSerialization();
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        if (Networking.LocalPlayer.IsOwner(this.gameObject))
        {
            RequestSerialization();
        }
    }

    public override void OnDeserialization()
    {
        m_InputField.text = m_SyncedString;
    }
}
