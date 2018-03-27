using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumHit : MonoBehaviour
{
    // two boolean flags that checks if it's the time to display the first and the second arrows depending on the user clicking on the bubbles
    public bool isTimeToActivateFirstNum;
    public bool isTimeToActivateSecondNum;

    public Renderer fistNumrenderer;
    public Renderer secondNumrenderer;
    public Bubble bubbleScript;

    /// <summary>
    /// at the start of the game we hide the two instruction numbers for the first pink bubble 
    /// </summary>
    void Start()
    {
        hideFirstNum();
        hideSecondNum();
    }

    /// <summary>
    /// Depending on the values of the boolean flags the instrucitons numbers will be revealed 
    /// </summary>
    void Update()
    {
        // this is set to true in the bubbles script when the user presses on the first blue bubble 
        if (isTimeToActivateFirstNum)
            revealFirstNum();

        // this is set to ture in the bubbles script when the user presses on the first pink bubble for the second time 
        if (isTimeToActivateSecondNum)
            revealSecondNum();

        // This hides the number ( x1 ) when the user clicks on the pink bubble once
        if (bubbleScript.isFirstPinkBubbleFirstClicked)
            hideFirstNum();

        // this hides the number ( x2 ) when the user clilcks on the pink bubble for the second time ,
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
