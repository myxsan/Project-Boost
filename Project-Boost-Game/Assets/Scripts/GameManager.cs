using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] float levelResetDelay = 0.7f;
    [SerializeField] float levelLoadDelay = 0.2f;

    private void Awake() {
        DontDestroyOnLoad(transform.gameObject);
    }
    public void ResetLevel()
    {
        Invoke("InvokeReset",levelResetDelay);
    }

    void InvokeReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        Invoke("InvokeLoad",levelLoadDelay);
    }

    void InvokeLoad()
    {
        int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextLevelIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextLevelIndex = 0;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }
}
