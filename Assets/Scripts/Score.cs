using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    string highScoreStore = "dino_highscore";
    Text scoreText;
    public Text hiScoreText;
    int score;

    float multiplier;
    float currentTime;

    public AudioSource soundOn100;
    // Start is called before the first frame update
    void Start()
    {
        hiScoreText.text = "HI " + PlayerPrefs.GetInt(highScoreStore, 0).ToString("00000");
        scoreText = GetComponent<Text>();
        score = 0;
        multiplier = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.timeScale == 0) {
            if (score > PlayerPrefs.GetInt(highScoreStore, 0)) {
                PlayerPrefs.SetInt(highScoreStore, score);
                hiScoreText.text = "HI " + score.ToString("00000");
            }
        }

        currentTime += Time.deltaTime;
        if (currentTime >= multiplier) {
            score++;
            scoreText.text = score.ToString("00000");
            currentTime = 0;

            if (score % 100 == 0) {
                soundOn100.Play();
                if(Time.timeScale < 1.5)
                    Time.timeScale += 0.1f;
            }

            if (score % 1000 == 0) { 
                Time.timeScale += 0.1f;
            }
        }
    }
}
