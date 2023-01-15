using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioEvents : MonoBehaviour
{
     AudioSource source;
    public AudioClip HammerClip;
    public AudioClip MopClip;
    public AudioClip Step;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void HammerAudio()
    {
        source.PlayOneShot(HammerClip);
    }
    public void MopAudio()
    {
        source.PlayOneShot(MopClip);
    }
    public void Steps()
    {
        source.PlayOneShot(Step);
    }
}
