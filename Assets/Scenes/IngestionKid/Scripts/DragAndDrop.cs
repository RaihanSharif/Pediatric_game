using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    private bool isDragged = false; //whether the player is currently dragging an item
    public GameObject spoon;   //holds a reference to an object being dragged
    private Vector2 touchOffset;    //allows a grabbed object to stick realistically to the player’s touch position (more about this later).

	// TODO: to be finished
    Animator anim; //Animator for the spoon
    public GameObject food; //Reference to the food
    Animator spoonAnimation; //What's the fucking difference? Will see when we merge
    public Sprite fullSpoon, emptySpoon; //References to the full and empty spoon images to render
    public GameObject kid; // Reference to the kid object
    private bool isRotated = false;
	public bool isFull = false; // tracks if spoon is full, used to ensure only one bite can be taken at a time
	public changeFoodOnContact foodScript; // Reference to the script to take off the bites

    public AudioClip impact;
    AudioSource audioSource;



    void Start()
    {
        spoon.SetActive(false);
		//TODO: tbd when we merge
        anim = gameObject.GetComponent<Animator>();
        spoonAnimation = food.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// calls the methods DropItems() and DragOrPickup() when required
    /// checks if the player is currently touching the screen and if 
    /// he is, Drag or pick up the object, otherwise drop the item
    /// </summary>
    void Update()
    {
        if (HasInput)
        {
            DragOrPickUp();
        }
        else
        {
            if (isDragged)
                DropItem();
        }

        float distance = Vector2.Distance(this.transform.position, kid.transform.position);
        if (distance < 6 )
        {
            //anim.SetTrigger("Active");
            int hash = Animator.StringToHash("flipSpoon");
            anim.Play(hash, 0, 0.8F);
            isRotated = true;
        }
        else if ( distance > 6 && distance < 7 )
        {
            // needs to search of how to only play it once. 
            anim.SetTrigger("Active");
        }
        else
        {
            int hashFirstHalf = Animator.StringToHash("flipSpoon");
            anim.Play(hashFirstHalf, 0, 0.0F);
            isRotated = false;
        }
        
        // prevents the spoon from leaving the scene
        Vector3 pos = Camera.main.WorldToViewportPoint (transform.position); 
		pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f); // second, third param prevents part of the spoon leaving scene
		pos.y = Mathf.Clamp(pos.y, 0.05f, 0.95f);
		transform.position = Camera.main.ViewportToWorldPoint(pos); //boilerplate

 

    }

    /// <summary>
    ///  returns the position of a detected touch/mouse input
    /// </summary>
    Vector2 CurrentTouchPosition
    {
        get
        {
            Vector2 inputPos;
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return inputPos;
        }
    }

    /// <summary>
    /// if an item is being dragged, move it with the input; 
    /// if an object is not being dragged, pick up an object 
    /// that’s being touched.
    /// </summary>
    private void DragOrPickUp()
    {
        var inputPosition = CurrentTouchPosition;

        if (isDragged)
        {
            spoon.transform.position = inputPosition + touchOffset;
        }
        else
        {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPosition, inputPosition, 0.5f);
            if (touches.Length > 0)
            {
                var hit = touches[0];
                if (hit.transform != null && hit.collider.name == "spoon")
                {
                    isDragged = true;
                    spoon = hit.transform.gameObject;
                    touchOffset = (Vector2)hit.transform.position - inputPosition;
                }
            }
        }
    }

    /// <summary>
    /// returns true when the player is currently
    /// touching the screen/holding the mouse button
    /// </summary>
    private bool HasInput
    {
        get
        {
            // returns true if either the mouse button is down or at least one touch is felt on the screen
            return Input.GetMouseButton(0);
        }
    }
    
    /// <summary>
    /// releases a picked up item
    /// </summary>
    void DropItem()
    {
        isDragged = false;
    }
	/// <summary>
	/// Raises the trigger enter2 d event. Handle the contact between the spoon and the food or kid
	/// colliders
	/// </summary>
	/// <param name="col">Col.</param>
    void OnTriggerEnter2D(Collider2D col)
    {   
		//if the spoon touches the food, check the food is not finished
		//and display full spoon
		if (col == food.GetComponent<Collider2D>() && (foodScript.frame <= 10))
		{ 
			this.GetComponent<SpriteRenderer>().sprite = fullSpoon;
			//Flag spoon as full
			isFull = true;

		} else if (col == kid.GetComponent<Collider2D>() && spoon.GetComponent<SpriteRenderer>().sprite.name != "SpoonOfNothing") 
		{ 
			//if the spoon touches the kid, display empty spoon
			//and flag spoon as empty
			this.GetComponent<SpriteRenderer>().sprite = emptySpoon;
			isFull = false;
            foodScript.isMouthOpen = false;
            audioSource.Play();

        }	
    }
}
