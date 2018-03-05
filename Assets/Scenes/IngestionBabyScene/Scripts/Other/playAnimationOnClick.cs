using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimationOnClick : MonoBehaviour {


    Animator anim;
    
    public GameObject simleyObject;
    Animator smileyAnimation;
    private int maxNumOfClicks = 0;
    public bool gameOver;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        smileyAnimation = simleyObject.GetComponent<Animator>();
    }



    void OnMouseDown()
    {
        if (maxNumOfClicks <= 6 && !gameOver)
        {
            
            smileyAnimation.SetTrigger("smileyActive");
            anim.SetTrigger("Active");
            maxNumOfClicks++;
        }   

    }

}
