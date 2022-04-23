using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Movement movement;
    Rigidbody playerRigidbody;
    [Header("Delay Amounts")]
    [SerializeField] float levelResetDelay = 0.7f;
    [SerializeField] float levelLoadDelay = 0.2f;


    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        movement = GameObject.Find("Rocket").GetComponent<Movement>();
    }
    public void StartResetLevel()
    {
        Invoke("ResetLevel",levelResetDelay);
        FindObjectOfType<Movement>().enabled = false;
        GameObject.Find("Rocket").GetComponent<Rigidbody>().useGravity = false;        
    }

    void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        
        Invoke("LevelLoad",levelLoadDelay);
        FindObjectOfType<Movement>().enabled = false;
        GameObject.Find("Rocket").GetComponent<Rigidbody>().useGravity = false;
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
