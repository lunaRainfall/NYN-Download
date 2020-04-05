using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [Header("Audios")]
    public AudioClip[] tunes;
    public AudioClip endMenu;
    public AudioSource audioSRC;
    [Header("Objects")]
    public PlatformController platControl;
    public GameObject blackScreen;
    private bool endScreen = false;

    public GameObject[] instructionsButtons;

	void Start () {
        blackScreen.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
    }
	
	void Update () {
        if (Input.anyKeyDown && endScreen == false)
        {
            blackScreen.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, .0f);
        }

        bool redKey = Input.GetKeyDown(KeyCode.J) || Input.GetKey(KeyCode.Z);
        bool greenKey = Input.GetKeyDown(KeyCode.K) || Input.GetKey(KeyCode.X);
        bool blueKey = Input.GetKeyDown(KeyCode.L) || Input.GetKey(KeyCode.C);

        if ((Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Z)) || Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Keypad1) ||Input.GetButtonDown("RedButton") && endScreen == false && platControl.redState == true)
        {
            instructionsButtons[0].gameObject.SetActive(false);
            audioSRC.PlayOneShot(tunes[0], 1.5f);
        }
        if ((Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.X)) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetButtonDown("GreenButton") && platControl.greenState == true && endScreen == false)
        {
            instructionsButtons[1].gameObject.SetActive(false);
            audioSRC.PlayOneShot(tunes[1], 1.5f);
        }
        if ((Input.GetKeyDown(KeyCode.L) || Input.GetKeyDown(KeyCode.C)) || Input.GetKeyDown(KeyCode.B) || Input.GetKeyDown(KeyCode.Keypad3) || Input.GetButtonDown("BlueButton") && platControl.blueState == true && endScreen == false)
        {
            instructionsButtons[2].gameObject.SetActive(false);
            audioSRC.PlayOneShot(tunes[2], 1.5f);
        }

        if(platControl.whiteState == true && endScreen == false)
        {
            endScreen = true;
            platControl.enabled = false;
            StartCoroutine(EndScene());
        }
    }

    public IEnumerator EndScene()
    {
        yield return new WaitForSeconds(0.1f);
        audioSRC.PlayOneShot(endMenu, 1.5f);
        yield return new WaitForSeconds(1f);
        blackScreen.GetComponent<Image>().material.color = new Color(1f, 1f, 1f, 1f);
        Animator blackAnim = blackScreen.GetComponent<Animator>();
        blackAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene("Level1");
    }
}
