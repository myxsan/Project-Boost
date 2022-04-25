using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    GameManager gameManager;
    [Header("Audio")]
    [SerializeField] AudioClip crashSFX;
    [SerializeField] AudioClip landingPadSFX;
    [SerializeField] ParticleSystem crashParticle;
    [SerializeField] ParticleSystem landingPadParticle;
    PlayerSFXController playerSFXController;
    AudioSource audioSource;


    [HideInInspector] public bool isAbleToTransition = true;

    private void Awake() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GameObject.Find("Rocket").GetComponent<AudioSource>();
        playerSFXController = GameObject.Find("Rocket").GetComponent<PlayerSFXController>();
    }
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "LaunchPad":
                Debug.Log("Let's gooo!");
                break;

            case "LandingPad":
                Debug.Log("You are late...");

                if(isAbleToTransition)
                {
                    gameManager.LoadNextLevel();
                    landingPadParticle.Play();
                    audioSource.PlayOneShot(landingPadSFX);
                    isAbleToTransition = false;
                }
                break;

            case "Fuel":
                Debug.Log("That one felt good");
                break;

            default:
                Debug.Log("Hey I am here!!");

                if(isAbleToTransition)
                {
                    gameManager.StartResetLevel();
                    audioSource.PlayOneShot(crashSFX);
                    isAbleToTransition = false;
                    crashParticle.Play();
                }
                break;
        }
    }
}
