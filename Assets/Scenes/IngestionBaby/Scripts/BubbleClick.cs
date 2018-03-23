using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleClick : MonoBehaviour
{

    private int numOfClick = 0; // counts the number of clicks that the user presses 
    public Bubble bubbleScript; // used to access public boolean flags in the bubbleScript 

    [SerializeField]
    public int bubbleNum = 0;  // the number that is assigned to each buble 

    // as the pink bubbles needs 2 clicks then these varaibles are counting the number of the clicks that each bubble being pressed
    private int countPinkBubble1Click = 0; 
    private int countPinkBubble2Click = 0;
    private int countPinkBubble3Click = 0;

    public Transform farEnd; // the end point that we want the object to be moved to ( baby bottle ), done by dragging the object in unity
    private Vector3 frometh; // the position of the object at the start of the game 
    private Vector3 untoeth; // the position of the last object 
    private float secondsForOneLength = 24f;
    bool firstPopped; // a boolean flag that checks if the first bubble is being clicked ( popped ) or not, this is used to dispaly the arrows and the num of clicks.

   ///
    void Start()
    {
        getPostionOfTheFirstAndLastObject();    
    }

    /// <summary>
    /// This is called at the start of the program where we get the positions of the starting object and the end object
    /// </summary>
    void getPostionOfTheFirstAndLastObject()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
            moveBubbles();       
    }

    /// <summary>
    /// This funciton makes the bubbles move after the second bubble is popped 
    /// </summary>
    void moveBubbles()
    {
        // bubbles start to move after the second bubble is being popped as the first and the second bubble are introductory 
        if (bubbleScript.isFirstPinkBubbleSecondClicked)
        {
            // Vector3.Lerp takes 3 parameters which are in the following order: form, to, float ( range [0, 1] ) which i the rate of the movement between the 2 objects 
            // the PingPong function moves back and forth between 0 and length. so that the bubbles are moving towords the baby bottle then moves back to its positon and back to baby bottle and so on
            transform.position = Vector3.Lerp(frometh, untoeth,
            Mathf.SmoothStep(0f, 0.5f,
            Mathf.PingPong(bubbleScript.timer / secondsForOneLength, 0.5f)
           ));
        }
    }

    /// <summary>
    /// this function checks which bubble is being clicked when the bubble is being clicked 
    /// When the blue bubbles are being pressed then setTrueTheNthBlueBubble is being called where the index of the blue bubble is passed 
    /// when a pink bubbles are being pressed then the clicking counter for that pink bubble will be incremented and if the num of clicks is 2 then 
    /// setTrueTheNthPinkBubble will be called and the index of the pink bubble is being passed 
    /// </summary>
    void OnMouseDown()
    {
		BubbleSourceSound.instance.playBubbleSound();

        // if the first bubble is being clicked ( popped ) then change the boolean flag in bubbleScript and the firstPoopped flag to true 
        if (bubbleNum == 1)
        {
            bubbleScript.isFirstBlueBubblePopped = true;
            bubbleScript.setTrueTheNthBlueBubble(0);
            firstPopped = true;
        }

        if (bubbleNum == 2)
        {
            bubbleScript.setTrueTheNthBlueBubble(1);
        }

        if (bubbleNum == 3)
        {
            bubbleScript.setTrueTheNthBlueBubble(2);
        }

        // when the second bubble ( in the order which they are being displayed ) is first clicked then isFirstPinkBubbleFirstClicked in bubbleScript is set to true which is used to dispay the object with the sprite 'x1'
        // when the same bubble is clicked for the second time then the isFirstPinkBubbleSecondClicked is set to true in the bubbleScript which is used to display the object with the sprite 'x2' 
        if (bubbleNum == 4)
        {
            countPinkBubble1Click += 1;
            bubbleScript.isFirstPinkBubbleFirstClicked = true;
            if ( countPinkBubble1Click == 2)
            {
                bubbleScript.setTrueTheNthPinkBubble(0);
                bubbleScript.isFirstPinkBubbleSecondClicked = true;
            }
        }

        if (bubbleNum == 5)
        {
            countPinkBubble2Click += 1;
            if (countPinkBubble2Click == 2)
            {
                bubbleScript.setTrueTheNthPinkBubble(1);
            }
        }

        // when the last bubble is being clicked then the lastBubbleClicked is set true which is used to dispaly the arrow that points to the baby bottle 
        if (bubbleNum == 6)
        {
            countPinkBubble3Click += 1;
            if (countPinkBubble3Click == 2)
            {
                bubbleScript.setTrueTheNthPinkBubble(2);
            }
           
        }
    }
}
