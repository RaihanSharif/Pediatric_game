using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumHit : MonoBehaviour
{

    public bool isTimeToActivateFirstNum;
    public bool isTimeToActivateSecondNum;
    public Renderer fistNumrenderer;
    public Renderer secondNumrenderer;
    public Bubble bubbleScript;

    // Use this for initialization
    void Start()
    {
        hideFirstNum();
        hideSecondNum();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTimeToActivateFirstNum)
            revealFirstNum();
        if (isTimeToActivateSecondNum)
            revealSecondNum();
        if (bubbleScript.isFirstPinkBubbleFirstClicked)
            hideFirstNum();
        if (bubbleScript.isFirstPinkBubbleSecondClicked)
            hideSecondNum();

    }

    void hideFirstNum()
    {
        fistNumrenderer.enabled = false;
    }

    void hideSecondNum()
    {
        secondNumrenderer.enabled = false;
    }

    void revealFirstNum()
    {
        fistNumrenderer.enabled = true;
    }

    void revealSecondNum()
    {
        secondNumrenderer.enabled = true;
    }
}
