using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleClick : MonoBehaviour
{

    private int numOfClick = 0;
    public Bubble bubbleScript;

    [SerializeField]
    public int bubbleNum = 0;

    private int countPinkBubble1Click = 0;
    private int countPinkBubble2Click = 0;
    private int countPinkBubble3Click = 0;

    public Transform farEnd;
    private Vector3 frometh;
    private Vector3 untoeth;
    private float secondsForOneLength = 24f;
    bool firstPopped;
    public bool lastBubbleClicked;

    void Start()
    {
        frometh = transform.position;
        untoeth = farEnd.position;
    }

    void Update()
    {
            moveBubbles();       
    }

    void moveBubbles()
    {
        if (firstPopped)
            Debug.Log("yeeeees");

        if (bubbleScript.isFirstPinkBubbleSecondClicked)
        {
            Debug.Log("this is running");
            transform.position = Vector3.Lerp(frometh, untoeth,
            Mathf.SmoothStep(0f, 0.5f,
             Mathf.PingPong(bubbleScript.timer / secondsForOneLength, 0.5f)
           ));
        }
    }

    void OnMouseDown()
    {
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
    

        if (bubbleNum == 6)
        {
            countPinkBubble3Click += 1;
            if (countPinkBubble3Click == 2)
            {
                bubbleScript.setTrueTheNthPinkBubble(2);
                lastBubbleClicked = true;
            }
           
        }
    }
}
