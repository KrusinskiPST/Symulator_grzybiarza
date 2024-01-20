using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackPlayer : MonoBehaviour

{
    public AudioClip[] SoundTracks;
    AudioSource AS;
    void Start()
    {
        AS = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(AS.isPlaying == false)
        {
            AS.clip = SoundTracks[Random.Range(0, SoundTracks.Length - 1)];
            AS.Play();
        }
    }
}
