using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation_Harmony : MonoBehaviour
{

    public float frameRate = 24.0f;
    public float Clip;
    private float lastclip;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        HarmonyAnimation animation = GetComponent<HarmonyAnimation>();
        animation.LoopAnimation(frameRate, (int)Clip);

        if (lastclip != Clip)
        {
            animation.ResetAnimation();
            lastclip = Clip;
        }

    }
}
