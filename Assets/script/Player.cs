using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

   
    private Rigidbody Rb;
    private bool MovingRight = false;
    private ScoreManager scoreScript;

    private int i = 0;
   
    //Audio
    public AudioClip SoundPlay;
    public AudioClip BackPlay1;
    public AudioClip BackPlay2;
    public AudioClip BackPlay3;
    public AudioClip BackPlay4;
    AudioSource AudioS;
    private AudioManager BAM;
   
    [HideInInspector]
    public  bool CanMove = true;
    

    [SerializeField]
    float speed = 1f;

    [SerializeField]
    GameObject particle;

    void Start()
    {
        Rb = this.GetComponent<Rigidbody>();
        scoreScript = GameObject.Find("scoreManager1").GetComponent<ScoreManager>();
        AudioS=GetComponent<AudioSource>();
        BAM = FindObjectOfType<AudioManager>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&CanMove)
        {
            Changebool();
            ChangeDirect();
        }
        if(Physics.Raycast(this.transform.position,Vector3.down*2)==false)
        {
            FallDown();
        }
        if(this.gameObject.transform.position.y<-3)
        {
            Destroy(gameObject);

        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ScoreManager.pause = true;
            CanMove = false;
        }

        //Change Level
        ChangeLevel();
     
        

        //
    }

    private void ChangeLevel()
    {
        switch (i)
        {
            case 0:
                if (scoreScript.myScore == 1)
                {
                    i++;
                }
                break;

            case 1:
                if (scoreScript.myScore == 10)
                {

                    BAM.ChangeMusic(BackPlay1);
                    speed = 4f;
                    scoreScript.AddLevel(2);
                    i++;

                }
                break;


            case 2:
                if (scoreScript.myScore == 20)
                {
                    
                    speed = 5f;
                    scoreScript.AddLevel(3);
                    i++;
                }
                break;

            case 3:

                if (scoreScript.myScore == 35)
                {
                    BAM.ChangeMusic(BackPlay2);
                    speed = 6f;
                    scoreScript.AddLevel(4);

                    i++;
                }
                break;

            case 4:
                if (scoreScript.myScore == 55)
                {
                    
                    speed = 7.5f;
                    scoreScript.AddLevel(5);
                    i++;
                }
                break;

            case 5:
                if (scoreScript.myScore == 80)
                {
                    BAM.ChangeMusic(BackPlay3);
                    speed = 8.2f;
                    scoreScript.AddLevel(6);
                    i++;
                }
                break;

            case 6:
                if (scoreScript.myScore == 100)
                {
                    BAM.ChangeMusic(BackPlay4);
                    speed = 9.5f;
                    scoreScript.AddLevel(7);
                    i++;
                }
                break;

            case 7:
                if (scoreScript.myScore == 150)
                {
                    speed = 11f;
                    scoreScript.AddLevel(8);
                    
                }
                break;
        }
    }

    //DEATH
    private void FallDown()
    {
        CanMove = false;
        Rb.velocity = new Vector3(0f, -4f, 0f);
        Time.timeScale = 1.0f;
        if(gameObject.transform.position.y<=18)
        ScoreManager.Dead = true;
        
        
    }

   


    //Movement
    private void Changebool()
    {
        MovingRight = !MovingRight;
    }

    private void ChangeDirect()
    {
        if (MovingRight)
        {
            Rb.velocity = new Vector3(speed, 0f, 0f);
        }
        else
        {
            Rb.velocity = new Vector3(0f, 0f, speed);
        }
    }


    //Gems Pick
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Gems")
        {
            Destroy(col.gameObject);
           
            scoreScript.AddScore(1);
            
            GameObject _particle = Instantiate(particle) as GameObject;
            _particle.transform.position = this.transform.position;
            AudioS.PlayOneShot(SoundPlay);
            Destroy(_particle, 1f);
        }

     
    }
}
