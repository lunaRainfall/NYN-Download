using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour
{
    public Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger("update");
    }

    public void HubUpdate(string color, bool hubStat)
    {
        if (color == "red")
        {
            anim.SetBool("red", hubStat);
        }
        else if (color == "green")
        {
            anim.SetBool("green", hubStat);
        }
        else
        {
            anim.SetBool("blue", hubStat);
        }

        anim.SetTrigger("update");
    }
}
