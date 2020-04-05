using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesColor : MonoBehaviour
{
    public ParticleSystem walkParticle;
    public ParticleSystem jumpParticle;
    public ParticleSystem fallParticle;
    public ParticleSystem rainbowParticle;

    public TrailRenderer hubTrail;

    public PlatformController platControl;

    public Gradient defaultGradient;
    public Gradient redGradient;
    public Gradient greenGradient;
    public Gradient blueGradient;
    public Gradient cyanGradient;
    public Gradient magentaGradient;
    public Gradient yellowGradient;
    public Gradient whiteGradient;
    public Gradient rainbowGradient;

    [Header("TRAIL GRADIENTS")]
    //public GameObject redParticles;
    public Gradient trailDefaultGradient;
    public Gradient trailRedGradient;
    public Gradient trailGreenGradient;
    public Gradient trailBlueGradient;
    public Gradient trailCyanGradient;
    public Gradient trailMagentaGradient;
    public Gradient trailYellowGradient;
    public Gradient trailRainbowGradient;

    void Start()
    {
        rainbowParticle.gameObject.SetActive(false);
        hubTrail.colorGradient = trailDefaultGradient;
    }

    void Update()
    {
        if (platControl.whiteState == false)
        {
            rainbowParticle.gameObject.SetActive(false);
        }
    }


    public void UpdateParticleColor()
    {
        var colWalk = walkParticle.colorOverLifetime;
        var colJump = jumpParticle.colorOverLifetime;
        var colFall = fallParticle.colorOverLifetime;

        if (platControl.greenState == true && !(platControl.blueState || platControl.redState))
        {

            colWalk.color = greenGradient;
            colJump.color = greenGradient;
            colFall.color = greenGradient;
            hubTrail.colorGradient = trailGreenGradient;

        }
        else if (platControl.redState == true && !(platControl.blueState || platControl.greenState))
        {

            colWalk.color = redGradient;
            colJump.color = redGradient;
            colFall.color = redGradient;
            hubTrail.colorGradient = trailRedGradient;
        }
        else if (platControl.blueState == true && !(platControl.redState || platControl.greenState))
        {

            colWalk.color = blueGradient;
            colJump.color = blueGradient;
            colFall.color = blueGradient;
            hubTrail.colorGradient = trailBlueGradient;
        }
        else if (platControl.cyanState == true && !(platControl.magentaState || platControl.yellowState))
        {

            colWalk.color = cyanGradient;
            colJump.color = cyanGradient;
            colFall.color = cyanGradient;
            hubTrail.colorGradient = trailCyanGradient;
        }
        else if (platControl.magentaState == true && !(platControl.cyanState || platControl.yellowState))
        {

            colWalk.color = magentaGradient;
            colJump.color = magentaGradient;
            colFall.color = magentaGradient;
            hubTrail.colorGradient = trailMagentaGradient;
        }
        else if (platControl.yellowState == true && !(platControl.cyanState || platControl.magentaState))
        {

            colWalk.color = yellowGradient;
            colJump.color = yellowGradient;
            colFall.color = yellowGradient;
            hubTrail.colorGradient = trailYellowGradient;
        }
        else if (platControl.yellowState && platControl.cyanState && platControl.magentaState)
        {

            colWalk.color = rainbowGradient;
            colJump.color = rainbowGradient;
            colFall.color = rainbowGradient;
            hubTrail.colorGradient = trailRainbowGradient;
            rainbowParticle.gameObject.SetActive(true);
        }
        else
        {

            colWalk.color = defaultGradient;
            colJump.color = defaultGradient;
            colFall.color = defaultGradient;
            hubTrail.colorGradient = trailDefaultGradient;
        }

    }
}

