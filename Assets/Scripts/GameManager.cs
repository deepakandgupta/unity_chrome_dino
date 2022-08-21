using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string replayCheck = "replay_dino";
    public GameObject startLevelUI;
    public GameObject gameoverUI;
    bool alreadyLoaded;
    public AudioSource dieSound;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt(replayCheck, 0) == 1)
        {
            Time.timeScale = 1;
            startLevelUI.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        Time.timeScale = 0;
        dieSound.Play();
        gameoverUI.SetActive(true);
        PlayerPrefs.SetInt(replayCheck, 0);
    }

    public void restartLevel() {
        SceneManager.LoadScene("Dinosaur");
        PlayerPrefs.SetInt(replayCheck, 1);
    }

    public void playLevel()
    {
        Time.timeScale = 1;
        startLevelUI.SetActive(false);
    }
}
