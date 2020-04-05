using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public Transform target;
    public float dist;
    public AstarPath path;
    public PlatformController platControl;
    public GameObject blackScreen;
    public string levelName;

    void Update () {
        dist = Vector2.Distance(transform.position, target.position);

        if(dist > 12)
        {
            path.enabled = false;
        }
        else
        {
            path.enabled = true;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(EndGame());
        }
    }

    public IEnumerator EndGame()
    {
        platControl.redState = false;
        platControl.greenState = false;
        platControl.blueState = false;
        platControl.enabled = false;
        blackScreen.GetComponent<Animator>().SetTrigger("Blackout");
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelName);
    }
}
