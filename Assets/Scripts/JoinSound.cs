
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class JoinSound : UdonSharpBehaviour
{
    AudioSource audioSource;
    AudioClip audioClip;
    //--------------------------------------- 
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        audioClip = audioSource.clip;
    }

    public override void OnPlayerJoined(VRCPlayerApi player)
    {
        PlaySound();
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
