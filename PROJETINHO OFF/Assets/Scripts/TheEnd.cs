using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class TheEnd : MonoBehaviour {

    public PlatformController platControl;
    public GameObject blackScreen;
    public GameObject blackScreen2;
    public CanvasGroup nynLetters;
    public GameObject finalHeart;
    public AudioSource audioSRC;
    public AudioClip finalSong;
    private bool end = false;
    private bool appearNyn = false;

    public AudioSource bgSound;

    public void Update()
    {
        if(appearNyn == true)
        {
            nynLetters.alpha += 0.015f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && end == false)
        {
            end = true;
            StartCoroutine(Final());
        }
    }

    public IEnumerator Final()
    {
        audioSRC.PlayOneShot(finalSong);
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        finalHeart.GetComponent<SpriteRenderer>().enabled = true;
        platControl.redState = false;
        platControl.greenState = false;
        platControl.blueState = false;
        platControl.enabled = false;
        blackScreen.GetComponent<Animator>().SetTrigger("Fade");
        bgSound.enabled = false;
        yield return new WaitForSeconds(5f);
        appearNyn = true;
        yield return new WaitForSeconds(2f);
        blackScreen2.GetComponent<Animator>().SetTrigger("Fade");
        yield return new WaitForSeconds(15f);
        SceneManager.LoadScene("Menu");
    }
}
