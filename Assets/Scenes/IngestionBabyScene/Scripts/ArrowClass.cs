using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClass : MonoBehaviour {

    public bool isTimeToActivateFirstArrow;
    public bool isTimeToActivateSecondArrow;
    public Renderer firstArrowRenderer;
    public Renderer secondArrowRenderer;
    public Renderer thirdArrowRenderer;
    public Bubble bubbleScript;
    public BubbleClick BubbleClickScript;
    public Babybottle BabybottleScript;

    // Use this for initialization
    void Start () {
        hideFirstArrow();
        hideSecondArrow();
        hideThirdArrow();
    }
	
	// Update is called once per frame
	void Update () {
        if (isTimeToActivateFirstArrow)
            revealFirstArrow();
	    if (isTimeToActivateSecondArrow)
	        revealSecondArrow();
	    if (BubbleClickScript.lastBubbleClicked)
	        revealThirdArrow();

        if (bubbleScript.isFirstBlueBubblePopped)
	        hideFirstArrow();
	    if (bubbleScript.isFirstPinkBubbleSecondClicked)
	        hideSecondArrow();
	    if (BubbleClickScript.lastBubbleClicked && BabybottleScript.FirstBottleClickAfterAllBubblesPopped)
	        hideThirdArrow();

	}

    void hideFirstArrow()
    {
        firstArrowRenderer.enabled = false;
    }

    void hideSecondArrow()
    {
        secondArrowRenderer.enabled = false;
    }

    void hideThirdArrow()
    {
        thirdArrowRenderer.enabled = false;
    }

    void revealFirstArrow()
    {
        firstArrowRenderer.enabled = true;
    }

    void revealSecondArrow()
    {
        secondArrowRenderer.enabled = true;
    }

    void revealThirdArrow()
    {
        thirdArrowRenderer.enabled = true;
    }
}
