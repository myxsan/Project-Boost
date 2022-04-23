using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Movement movement;
    Rigidbody playerRigidbody;
    [SerializeField] float levelResetDelay = 0.7f;
    [SerializeField] float levelLoadDelay = 0.2f;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        movement = GameObject.Find("Rocket").GetComponent<Movement>();
    }
    public void ResetLevel()
    {
        Invoke("ResetScene",levelResetDelay);
        
        FindObjectOfType<Movement>().enabled = false;
        GameObject.Find("Rocket").GetComponent<Rigidbody>().useGravity = false;
        //GameObject.Find("Rocket").GetComponent<AudioSource>().enabled = false;
    }

    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Invoke("LevelLoad",levelLoadDelay);
    }

    void LevelLoad()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }
}
