using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource BGM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMusic(AudioClip Music)
    {
        BGM.Stop();
        BGM.clip = Music;
        BGM.Play();
    }
}
