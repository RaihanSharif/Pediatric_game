using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to change the food sprite in response to spooning up the food.
/// </summary>
public class changeFoodOnContact : MonoBehaviour {

	// array of sprites representing the food
    public Sprite[] mySprites;  
	public DragAndDrop spoonScript; // the script attached to the spoon for drag and drop
    public int frame = 0;  // refers to the number of 'bites' taken so far
    public bool isMouthOpen;

    public AudioClip kidsCheeringSoundEffect;
    AudioSource audioSource;

    // Use this for initialisation
    void Start ()
    {
        isMouthOpen = false;
        // redender the first sprite in the food multisprite, a.k.a. the full plate
        this.GetComponent<SpriteRenderer>().sprite = mySprites[0];
        audioSource = GetComponent<AudioSource>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {   

        isMouthOpen = true;
        // for the first 24 "bites" the sprite changes to the next one in the multisprite,
        // then on the 24th instance, the sprite renderer is switched off, i.e. "Food finished"
        if (frame < 10 && !spoonScript.isFull) 
		{
			this.GetComponent<SpriteRenderer>().sprite = mySprites[frame++];
            isMouthOpen = true;

        } else if (frame == 10) {
            audioSource.Play();
            spoonScript.enabled = false;
			this.GetComponent<SpriteRenderer>().enabled = false;
			frame++;

		}

        
    }


}
