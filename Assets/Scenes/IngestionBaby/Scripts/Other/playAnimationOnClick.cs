using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimationOnClick : MonoBehaviour {


    Animator babyBottleAnimation;
    Animator smileyAnimation;

    public GameObject simleyObject;
    private int NumOfClicks = 0;
    public bool gameOver;
    public bool bottleEnabled;
    public Bubble bubbleScript;

    void Start()
    {
        setAnimators();
    }

    /// <summary>
    /// This sets the animators for the smiley face and the baby bottle 
    /// </summary>
    void setAnimators()
    {
        babyBottleAnimation = gameObject.GetComponent<Animator>();
        smileyAnimation = simleyObject.GetComponent<Animator>();
    }

    /// <summary>
    /// This is called everytime the baby bottle is clicked
    /// </summary>
    public void OnMouseDown()
    {
        // checks if the number of clicks is less than or equal to 5 ( as we are starting to count from 0 but the baby bottle can be clicked 6 times )
        // and checks if the baby bottle is enabled and checks if the first pink bubble is clicked for the second time 
        if (NumOfClicks <= 5 && !gameOver && bottleEnabled && bubbleScript.isFirstPinkBubbleSecondClicked)
        {
            // trigers the animations for the smiley face and the baby bottle 
            smileyAnimation.SetTrigger("smileyActive");
            babyBottleAnimation.SetTrigger("Active");
            NumOfClicks++;
        }

        babyBottleAnimation.SetTrigger("notActive");
        smileyAnimation.SetTrigger("smileyNotActive");

    }

}
