using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimationOnClick : MonoBehaviour {


    Animator anim;
    
    public GameObject simleyObject;
    Animator smileyAnimation;
    private int maxNumOfClicks = 0;
    public bool gameOver;
    public bool bottleEnabled;
    public Bubble bubbleScript;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        smileyAnimation = simleyObject.GetComponent<Animator>();
    }



    void OnMouseDown()
    {
        if (maxNumOfClicks <= 5 && !gameOver && bottleEnabled && bubbleScript.isFirstPinkBubbleSecondClicked)
        {
            
            smileyAnimation.SetTrigger("smileyActive");
            anim.SetTrigger("Active");
            maxNumOfClicks++;
        }

    }

}
