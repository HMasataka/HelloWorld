using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

public class GetPlayers : UdonSharpBehaviour
{
    VRCPlayerApi[] players = new VRCPlayerApi[30];

    void Start()
    {
        VRCPlayerApi.GetPlayers(players);

        foreach (VRCPlayerApi player in players)
        {
            if (player == null) continue;
            Debug.Log(player.displayName);
        }
    }
    void Update()
    {
        VRCPlayerApi.GetPlayers(players);

        foreach (VRCPlayerApi player in players)
        {
            if (player == null) continue;
            Debug.Log(player.displayName);
            Debug.Log(player.GetPosition());
        }
    }
}