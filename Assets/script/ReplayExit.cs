using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ReplayExit : MonoBehaviour
{




    public Player player;
    
    public void Play()
    {

        SceneManager.LoadScene("GameMain", LoadSceneMode.Single);
        ScoreManager.Dead = false;
        Time.timeScale = 1;
        //Application.LoadLevel(Application.loadedLevel);
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }



    public void Exit()
    {
        Application.Quit();
    }

    public void Paused()
    {
        ScoreManager.pause = false;
        player.CanMove = true;
    }
}
