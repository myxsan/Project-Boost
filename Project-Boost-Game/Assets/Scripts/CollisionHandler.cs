using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    GameManager gameManager;
    private void Awake() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
                gameManager.LoadNextLevel();
                break;
            case "Fuel":
                Debug.Log("That one felt good");
                break;
            case "Obstacle":
                Debug.Log("You bloody, just try to be nice. OK?");
                gameManager.ResetLevel();
                break;
            default:
                Debug.Log("Hey I am here!!");
                gameManager.ResetLevel();
                break;
        }
    }
}
