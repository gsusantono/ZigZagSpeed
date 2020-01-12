using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Text HighScore;
    private int Resetscore = 0;


    

    void Start()
    {
        HighScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    //Reset Score
    public void ResetScore()
    {
        if (PlayerPrefs.GetInt("HighScore") > 0)
        {
            PlayerPrefs.SetInt("HighScore", Resetscore);
        }
        HighScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
    }
   

}
