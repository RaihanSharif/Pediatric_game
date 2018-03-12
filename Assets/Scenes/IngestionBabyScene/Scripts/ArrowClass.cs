using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClass : MonoBehaviour {

    // This flag is set to true when timer is more than 3 seconds. It's being done in the Bubble class 
    public bool isTimeToActivateFirstArrow;
    // This falg is set to true when the first bubble is being clicked. It's being done in the Bubble class 
    public bool isTimeToActivateSecondArrow;
    // This flag is set to true whne the all bubbles are popped and time is more than 10
    public bool isTimeToActivateThirdArrow;

    // the sprite for each arrow draged and droped in Unity 
    public Renderer firstArrowRenderer;
    public Renderer secondArrowRenderer;
    public Renderer thirdArrowRenderer;

    public Bubble bubbleScript;
    public BubbleClick BubbleClickScript;
    public Babybottle BabybottleScript;

    /// <summary>
    /// At the start of the game all the arrows are hidden 
    /// </summary>
    void Start () {
        hideFirstArrow();
        hideSecondArrow();
        hideThirdArrow();
    }

    /// <summary>
    /// This functions reveals and hides arrows based on different if conditons 
    /// </summary>
    void Update () {
        if (isTimeToActivateFirstArrow)
            revealFirstArrow();
	    if (isTimeToActivateSecondArrow)
	        revealSecondArrow();
	    if (isTimeToActivateThirdArrow)
	        revealThirdArrow();

        if (bubbleScript.isFirstBlueBubblePopped)
	        hideFirstArrow();
	    if (bubbleScript.isFirstPinkBubbleSecondClicked)
	        hideSecondArrow();
	    if (isTimeToActivateThirdArrow && BabybottleScript.FirstBottleClickAfterAllBubblesPopped)
	        hideThirdArrow();
	}

    /// <summary>
    /// hides the first arrow ( pointing to the first blue bubble ). This is called when the first blue bubble is clicked 
    /// </summary>
    void hideFirstArrow()
    {
        firstArrowRenderer.enabled = false;
    }

    /// <summary>
    /// hides the second arrow ( pointing to the first pink bubble ). This is called when the first pink bubble is double clicked 
    /// </summary>
    void hideSecondArrow()
    {
        secondArrowRenderer.enabled = false;
    }

    /// <summary>
    /// hides the third arrow ( pointing to the baby bottle ). This is called when the baby bottle is once clicked after all the bubbles are popped 
    /// </summary>
    void hideThirdArrow()
    {
        thirdArrowRenderer.enabled = false;
    }

    /// <summary>
    /// This reveals the first arrow ( pointing at the first blue bubble ). This is called when the timer is 3 seocnd or more 
    /// </summary>
    void revealFirstArrow()
    {
        firstArrowRenderer.enabled = true;
    }

    /// <summary>
    /// This reveals the second arrow ( pointing at the first pink bubble ). This is called when the first blue bubble is popped
    /// </summary>
    void revealSecondArrow()
    {
        secondArrowRenderer.enabled = true;
    }

    /// <summary>
    /// This reveals the third arrow ( pointing at the baby bottle ). This is called when all bubbles are popped 
    /// </summary>
    void revealThirdArrow()
    {
        thirdArrowRenderer.enabled = true;
    }
}
