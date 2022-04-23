using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    GameManager gameManager;
    PlayerSFXController playerSFXController;
    AudioSource audioSource;
    private void Awake() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        playerSFXController = GetComponent<PlayerSFXController>();
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
                audioSource.PlayOneShot(playerSFXController.landingPad);
                gameManager.LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("That one felt good");
                break;
            default:
                Debug.Log("Hey I am here!!");
                gameManager.ResetLevel();
                audioSource.PlayOneShot(playerSFXController.crashToObstacle);
                break;
        }
    }
}
