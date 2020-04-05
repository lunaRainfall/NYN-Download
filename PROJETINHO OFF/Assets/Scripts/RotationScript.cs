using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public float speed;
    //public CameraFollow followScript;
    public PlayerController playerControl;

    private void Awake()
    {
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //followScript = GetComponent<CameraFollow>();
    }

    void Update()
    {
        //if (playerControl.facingRight)
        //{
            transform.Rotate(new Vector3(0f, 0f, 1f) * -speed * Time.deltaTime);
            //followScript.offset = new Vector3(-2.16f, 2.29f, 0);
        //}
        //else
        //{
          //  transform.Rotate(new Vector3(0f, 0f, 1f) * speed * Time.deltaTime);
            //followScript.offset = new Vector3(2.16f, 2.29f, 0);
        //}
    }
}
