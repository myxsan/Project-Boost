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

    List<GameObject> singletonPattern = new List<GameObject>();
    private void Awake() {
        singletonPattern.Add(this.gameObject);
        if(singletonPattern.Count > 1){
            Destroy(this.gameObject);
        }
        else if(singletonPattern.Count <= 1){
            DontDestroyOnLoad(transform.gameObject);
        }
        movement = GameObject.Find("Rocket").GetComponent<Movement>();
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
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
