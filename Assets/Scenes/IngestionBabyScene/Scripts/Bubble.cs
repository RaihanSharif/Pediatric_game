using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{

    public float timer = 0.0f; // timer which is used to display bubbles at certain times 

    public GameObject[] blueBubbles; 
    public GameObject[] pinkBubbles;
    public GameObject[] greenBubbles;

    public Text losingText; // dispalyed when there are 3 any 3 bubbles on the screen at the same time 
    public Text winningText;  // displayed when the baby bottle is empty ( all the milk is drunk ). Technically when the baby bottle is pressed 6 times 

    private int totalUnPoppedBubbles = 0;

    // array for each of the bubble colours which stores if the bubble is popped or not. This is done using one of the 3 functions setTrueTheNthBlueBubble, setTrueTheNthPinkBubble, setTrueTheNthGreenBubble
    [SerializeField]
    private bool[] blueBubblesFinished;

    [SerializeField]
    private bool[] pinkBubblesFinished;

    [SerializeField]
    private bool[] greenBubblesFinished;

    public Babybottle babyBottleScript; 
    public playAnimationOnClick playAnimationOnClickScript;
    public ArrowClass arrowScript;
    public NumHit numHit1Script;
    public NumHit numHit2Script;
    public bool isFirstBlueBubblePopped;
    public bool isFirstPinkBubbleFirstClicked;
    public bool isFirstPinkBubbleSecondClicked;
    public GameObject arrowObject;
    



    /// <summary>
    /// At the start of the game all the texts and all the bubbles are hidden 
    /// </summary>
    void Start()
    {
        hideAllText();
        hideAllBubbleAtStart();
    }


    // Update is called once per frame
    void Update()
    {

        if (checkLostGame())
            gameOver();

        startTimer();
        showBubbles();
        hideBubblesAfterClicks();
        if (checkGameWon())
            gameWon();

        if (totalUnPoppedBubbles == 0 && timer > 10)
            enableBabyBottle();
    }


    void showBubbles()
    {
        if (timer > 3 && blueBubblesFinished[0] == false)
        {
            arrowScript.isTimeToActivateFirstArrow = true;
            blueBubbles[0].SetActive(true);
        }

        if (timer > 4 && pinkBubblesFinished[0] == false && isFirstBlueBubblePopped)
        {
            arrowScript.isTimeToActivateSecondArrow = true;
            numHit1Script.isTimeToActivateFirstNum = true;
            if (isFirstPinkBubbleFirstClicked)
                numHit2Script.isTimeToActivateSecondNum = true;

            pinkBubbles[0].SetActive(true);
        }

        if (timer > 5 && blueBubblesFinished[1] == false && isFirstBlueBubblePopped && isFirstPinkBubbleSecondClicked)
        {
            blueBubbles[1].SetActive(true);
        }


        if (timer > 7 && blueBubblesFinished[2] == false && isFirstBlueBubblePopped && isFirstPinkBubbleSecondClicked)
        {
            blueBubbles[2].SetActive(true);
        }

        if (timer > 9 && pinkBubblesFinished[1] == false && isFirstBlueBubblePopped && isFirstPinkBubbleSecondClicked)
        {
            pinkBubbles[1].SetActive(true);
        }

        if (timer > 10 && pinkBubblesFinished[2] == false && isFirstBlueBubblePopped && isFirstPinkBubbleSecondClicked)
        {
            pinkBubbles[2].SetActive(true);
        }
    }

    void startTimer()
    {
        if (timer < 3 || (timer > 3 && isFirstBlueBubblePopped && timer < 4)  || ( timer > 4 && isFirstPinkBubbleSecondClicked) )
            timer += Time.deltaTime;
    }

    void hideBubblesAfterClicks()
    {
        if (blueBubblesFinished[0])
        {
            blueBubbles[0].SetActive(false);
        }

        if (blueBubblesFinished[1])
        {
            blueBubbles[1].SetActive(false);
        }

        if (blueBubblesFinished[2])
        {
            blueBubbles[2].SetActive(false);
        }

        if (pinkBubblesFinished[0])
        {
            pinkBubbles[0].SetActive(false);
        }

        if (pinkBubblesFinished[1])
        {
            pinkBubbles[1].SetActive(false);
        }

        if (pinkBubblesFinished[2])
        {
            pinkBubbles[2].SetActive(false);
        }
    }

    /// <summary>
    /// This is called at the start of the game which goes through each array for each bubble colours and sets active of each bubble to false 
    /// </summary>
    void hideAllBubbleAtStart()
    {
        foreach (GameObject bubble in blueBubbles)
        {
            bubble.SetActive(false);
        }

        foreach ( GameObject bubble in pinkBubbles)
        {
            bubble.SetActive(false);
        }

        foreach (GameObject bubble in greenBubbles)
        {
            bubble.SetActive(false);
        }
    }

    /// <summary>
    /// This is called at the start of the game where it set the enable function in each text to false 
    /// </summary>
    void hideAllText()
    {
        losingText.enabled = false;
        winningText.enabled = false;
    }

    /// <summary>
    /// This is called whenever a blue bubble is being clicked, it takes int parameter which is the index of the bubble being clicked 
    /// </summary>
    /// <param name="n"></param>
    public void setTrueTheNthBlueBubble(int n)
    {
        blueBubblesFinished[n] = true;
    }

    /// <summary>
    /// This is called whenever a pink bubble is being clicked, it takes int parameter which is the index of the bubble being clicked 
    /// </summary>
    /// <param name="n"></param>
    public void setTrueTheNthPinkBubble(int n)
    {
        pinkBubblesFinished[n] = true;
    }

    /// <summary>
    /// This is called whenever a green bubble is being clicked, it take int parameter which is the index of the bubble being clicked 
    /// </summary>
    /// <param name="n"></param>
    /*
        public void setTrueTheNthGreenBubble(int n)
        {
            greenBubblesFinished[n] = true;
        }

        public GameObject getNthGreenBubble(int n)
        {
            return blueBubbles[n];
        }

        public GameObject getNthPinkBubble(int n)
        {
            return pinkBubbles[n];
        }

        public GameObject getNthBlueBubble(int n)
        {
            return blueBubbles[n];
        }
    */

    /// <summary>
    /// This is called in the update method where it checks if the user lost the game or not. if there are 3 or more bubbles dispalyed on the screen 
    /// at the same time then the user loses the game. 
    /// </summary>
    public bool checkLostGame()
    {
        int unpoppedBlueBubbles = 0;
        int unpoppedPinkBubbles = 0;
        int unpoppedGreenBubbles = 0;

        // going through each bubble in the blueBubbles array and checks if there is an active bubbles and if there are active bubbles 
        // then for each active bubble it increments the unpoppedBlueBubbles
        // Note that the same thing is being doen to other bubbles as well 
        foreach (GameObject blueBubble in blueBubbles)
        {
            if (blueBubble.activeSelf)
            {
                unpoppedBlueBubbles += 1;
            }
        }

        foreach (GameObject pinkBubble in pinkBubbles)
        {
            if (pinkBubble.activeSelf)
            {
                unpoppedPinkBubbles += 1;
            }
        }

        foreach (GameObject blueBubble in greenBubbles)
        {
            if (blueBubble.activeSelf)
            {
                unpoppedGreenBubbles += 1;
            }
        }

        totalUnPoppedBubbles = unpoppedBlueBubbles + unpoppedPinkBubbles + unpoppedGreenBubbles;

        // if the sum of the active bubbles in each array is more that 3 then returns true indicating that the user lost the game 
        if (totalUnPoppedBubbles >= 3)
            return true;

        // otherwise the use has not lost the game yet 
        return false;
    }

    void enableBabyBottle()
    {
        playAnimationOnClickScript.bottleEnabled = true;
        babyBottleScript.bottleEnabled = true;
        arrowScript.isTimeToActivateThirdArrow = true;
    }


    /// <summary>
    /// This is called when checkLostGame returns true. 
    /// </summary>
    public void gameOver()
    {
        // sets the falg gameOver in babyBottleScript to true
        babyBottleScript.gameOver = true;
        // sets the flag gameOver in playAnimaitonOnClickScript to true
        playAnimationOnClickScript.gameOver = true;
        // removes the smiley object 
        Destroy(playAnimationOnClickScript.simleyObject);  
        // pauses the game 
        Time.timeScale = 0;
        timer = 0;
        hideAllBubbleAtStart();
        losingText.enabled = true;

    }

    /// <summary>
    /// This is called in the update method where it checks if the user won the game or not. The user wons the game when all the milk is being drunk 
    /// which means that the babyBottle is pressed 6 times when the baby bottle is enabled 
    /// </summary>
    /// <returns></returns>
    public bool checkGameWon()
    {
        if (babyBottleScript.gameWon)
            return true;

        return false;
    }

    /// <summary>
    /// This is called when checkGameWon return true
    /// </summary>
    public void gameWon()
    {
       
        winningText.enabled = true;
        hideAllBubbleAtStart();
    }



    
}