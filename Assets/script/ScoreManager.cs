using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static bool Dead;
    public Button PlayButton;
    public Button ExitButton;
    public Button BackMainMenu;
    public Button ResumeButton;
    public static bool pause;
    //score
    public Text ScoreText;
    public Text Level;
    public Text Highscore;
    public int myScore = 0;
    public int levelnow = 1;
    //audio
    public AudioClip HighSound;
   

 


    void Start () {
        myScore = 0;
        Dead = false;
        pause = false;
       
        Highscore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");

      

    }


    void Update()
    {
        ScoreText.text = "Score:" + myScore;
        Level.text = "Level:" + levelnow;




        if (Dead)
        {
            HighScore();
            PlayButton.gameObject.SetActive(true);
            ExitButton.gameObject.SetActive(true);
            BackMainMenu.gameObject.SetActive(true);
            Time.timeScale = 0f;

        }
        else if (pause)
        {
            ResumeButton.gameObject.SetActive(true);
            ExitButton.gameObject.SetActive(true);
            BackMainMenu.gameObject.SetActive(true);
            Time.timeScale = 0f;
         
        }
        else if (!pause)
        {
            ResumeButton.gameObject.SetActive(false);
            ExitButton.gameObject.SetActive(false);
            BackMainMenu.gameObject.SetActive(false);
            Time.timeScale = 1f;
            
        }
        else
        {
            Time.timeScale = 1;
            
        }
      }
   

    public void AddScore(int score)
    {
        myScore += score;
       
            

         if (PlayerPrefs.GetInt("HighScore") < myScore)
        {
            
            Highscore.text = "HIGH SCORE: " + myScore;
            PlayerPrefs.SetInt("HighScore", myScore);
           
        }
    }
    public void AddLevel(int level)
    {
        levelnow = level;
    }

    public void HighScore()
    {
        if(PlayerPrefs.GetInt("HighScore")<myScore)
        PlayerPrefs.SetInt("HighScore", myScore);
        
    }
    
  
    
}
