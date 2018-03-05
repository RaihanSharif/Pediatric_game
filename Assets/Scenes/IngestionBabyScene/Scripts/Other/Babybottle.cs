using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Babybottle : MonoBehaviour {

    public Sprite P100,  P80, P70, P60, P50, P40, P20, P0;
    public int ctr = 0;
    AudioSource sound;
    public AudioClip win;
    public AudioClip MilkDrunk;
    private bool playedSound = false;
    public bool gameOver;


    void Start(){

    	this.GetComponent<SpriteRenderer>().sprite = P20;
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
		
        if (!gameOver)
        {
            if (ctr <= 6)
            {
                sound.PlayOneShot(MilkDrunk);
            }

            ctr++;
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
                this.GetComponent<SpriteRenderer>().sprite = P80;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = P70;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = P60;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = P50;
                break;
            case 5:
                this.GetComponent<SpriteRenderer>().sprite = P40;
                break;
            case 6:
                this.GetComponent<SpriteRenderer>().sprite = P20;
                break;
            case 7:
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



