using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class EndLevel : MonoBehaviour {
    public Animator blackAnim;
    public string nextScene;

    [Header("Audio")]
    public AudioSource audioSRC;
    public AudioClip winSound;

    [Header("Slider")]
    public AudioScript audScript;
    
    public void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeScene());
        }
    }

    public IEnumerator ChangeScene()
    {
        blackAnim.SetTrigger("Fade");
        audioSRC.PlayOneShot(winSound, 1f);
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(5.5f);
        SceneManager.LoadScene(nextScene);
    }
}
