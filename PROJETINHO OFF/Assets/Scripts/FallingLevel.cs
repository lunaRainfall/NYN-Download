using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLevel : MonoBehaviour {

    public Animator blackScreen;
    public Enemy enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        blackScreen.SetTrigger("Fall");
        StartCoroutine(fallLevel());
    }

    public IEnumerator fallLevel()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(enemy.EndGame());
    }
}
