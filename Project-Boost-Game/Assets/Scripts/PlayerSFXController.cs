using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerSFXController : MonoBehaviour
{
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        AudioControl();
    }

    private void AudioControl()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        if(Input.GetKeyUp(KeyCode.Space) && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
