using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babybottle : MonoBehaviour {

    public Sprite P100,  P90, P80, P60, P40, P20, P0;
    public int ctr = 0;
    AudioSource sound;
    public AudioClip win;
    public AudioClip MilkDrunk;
    private bool playedSound = false;
    public bool gameOver;
    public bool bottleEnabled;
    public bool gameWon;
    public Bubble bubbleScript;
    public bool FirstBottleClickAfterAllBubblesPopped;
    public BubbleClick BubbleClickScript;
    public ArrowClass arrowClass;


    void Start(){

    	this.GetComponent<SpriteRenderer>().sprite = P100;
        sound = GetComponent<AudioSource>();
    }
    

    void Update()
    {
        changeSprite();
    }

    void playSound()
    {
        sound.PlayOneShot(win);
    }

    void OnMouseDown()
    {
        if (arrowClass.isTimeToActivateThirdArrow)
            FirstBottleClickAfterAllBubblesPopped = true;

        if (!gameOver && bottleEnabled && bubbleScript.isFirstPinkBubbleSecondClicked)
        {
            if (ctr <= 5)
            {
                sound.PlayOneShot(MilkDrunk);
            }

            ctr++;
        }

        if (ctr == 6)
        {
            gameWon = true;
        }

    }

    void changeSprite()
    {
        switch (ctr)
        {

            case 0:
                this.GetComponent<SpriteRenderer>().sprite = P100;
                break;

            case 1:
                this.GetComponent<SpriteRenderer>().sprite = P90;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = P80;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = P60;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = P40;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = P20;
                break;
            case 6:
                this.GetComponent<SpriteRenderer>().sprite = P0;

                if (!playedSound)
                {
                    playSound();
                    playedSound = true;
                }

                break;

        }
    }

}



