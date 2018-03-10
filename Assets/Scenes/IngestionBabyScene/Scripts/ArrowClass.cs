using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClass : MonoBehaviour {

    public bool isTimeToActivateFirstArrow;
    public bool isTimeToActivateSecondArrow;
    public Renderer firstArrowrenderer;
    public Renderer secondArrowrenderer;

    public Bubble bubbleScript;

    // Use this for initialization
    void Start () {
        hideFirstArrow();
        hideSecondArrow();
    }
	
	// Update is called once per frame
	void Update () {
        if (isTimeToActivateFirstArrow)
            revealFirstArrow();
	    if (isTimeToActivateSecondArrow)
	        revealSecondArrow();
	    if (bubbleScript.isFirstBlueBubblePopped)
	        hideFirstArrow();
	    if (bubbleScript.isFirstPinkBubbleSecondClicked)
	        hideSecondArrow();


    }

    void hideFirstArrow()
    {
        firstArrowrenderer.enabled = false;
    }

    void hideSecondArrow()
    {
        secondArrowrenderer.enabled = false;
    }

    void revealFirstArrow()
    {
        firstArrowrenderer.enabled = true;
    }

    void revealSecondArrow()
    {
        secondArrowrenderer.enabled = true;
    }
}
