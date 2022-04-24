using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class PlayerSFXController : MonoBehaviour
{
    [Header("Audios")]
    [SerializeField] AudioClip mainEngine;
    public AudioClip crashToObstacle;
    public AudioClip landingPad;
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
        if(GetComponent<CollisionHandler>().isAbleToTransition)
        {
            if(Input.GetKeyDown(KeyCode.Space) && !audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngine);
            }
              
        }
        if(Input.GetKeyUp(KeyCode.Space) && audioSource.isPlaying)
        {
            audioSource.Stop();
        } 
    }
}
