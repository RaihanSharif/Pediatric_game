using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeFoodOnContact : MonoBehaviour {

    public Sprite[] mySprites;
    public GameObject spoon;
    public GameObject kid;
    private int frame = 0;

    //Constant declarations for last item touched and in contact state
    private const bool CONTACT = true;
    private const bool FOOD = true;
    private const bool KID = false;
    //Flags for last item touched and in contact state
    private bool inContact = !CONTACT;
    private bool lastThingTouched = KID;

    // Use this for initialization
    void Start ()
    {
        // this.GetComponent<SpriteRenderer>().sprite = foods[0];
        this.GetComponent<SpriteRenderer>().sprite = mySprites[0];
    }
	
	// Update is called once per frame
	void Update ()
    {
        // if spoon is on food set flag to true
        //when spoon leaves food set flag to false and render food without last bite

        if (spoon.transform.position == this.transform.position)
        {
            Debug.Log("heeeet");
            //this.GetComponent<SpriteRenderer>().sprite = foods[1];
            // food.GetComponent<SpriteRenderer>().sprite = food.GetComponent<SpriteRenderer>().sprite + 1;
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("New heeeey");
        //this.GetComponent<SpriteRenderer>().sprite = foods[2];
        this.GetComponent<SpriteRenderer>().sprite = mySprites[frame++];
        
    }


}
