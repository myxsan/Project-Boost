using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "LaunchPad":
                Debug.Log("Let's gooo!");
                break;
            case "LandingPad":
                Debug.Log("You are late...");
                break;
            case "Fuel":
                Debug.Log("That one felt good");
                break;
            case "Obstacle":
                Debug.Log("You bloody, just try to be nice. OK?");
                SceneManager.LoadScene(0);
                break;
            default:
                Debug.Log("Hey I am here!!");
                SceneManager.LoadScene(0);
                break;
        }
    }
}
