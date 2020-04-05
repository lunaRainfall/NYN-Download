using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {
    public PlatformController platControl;

    public AudioClip redSong;
    public AudioClip greenSong;
    public AudioClip blueSong;
    public AudioClip whiteSong;
    public AudioClip bgSong;

    public float sliderValue = 0.05f;

    public AudioSource musicSourceRed;
    public AudioSource musicSourceBlue;
    public AudioSource musicSourceGreen;
    public AudioSource musicSourceWhite;
    public AudioSource musicSourceBackground;

    // Use this for initialization
    void Start () {
        musicSourceRed.clip = redSong;
        musicSourceBlue.clip = blueSong;
        musicSourceWhite.clip = whiteSong;
        musicSourceGreen.clip = greenSong;
        musicSourceBackground.clip = bgSong;


        musicSourceRed.volume = 0;
        musicSourceBlue.volume = 0;
        musicSourceGreen.volume = 0;
        musicSourceWhite.volume = 0;

        musicSourceRed.Play();
        musicSourceBlue.Play();
        musicSourceGreen.Play();
        musicSourceWhite.Play();
        musicSourceBackground.Play();
    }
	
	// Update is called once per frame
	void Update () {
		if(platControl.redState == true)
        {
            musicSourceRed.volume += sliderValue;
        }
        else
        {
            musicSourceRed.volume -= sliderValue;
        }

        if (platControl.greenState == true)
        {
            musicSourceGreen.volume += sliderValue;
        }
        else
        {
            musicSourceGreen.volume -= sliderValue;
        }

        if (platControl.blueState == true)
        {
            musicSourceBlue.volume += sliderValue;
        }
        else
        {
            musicSourceBlue.volume -= sliderValue;
        }

        if (platControl.redState == true && platControl.blueState == true && platControl.greenState == true)
        {
            musicSourceWhite.volume += sliderValue;
        }
        else
        {
            musicSourceWhite.volume -= sliderValue;
        }
    }
}
