using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bubble : MonoBehaviour
{

    public float timer = 0.0f;

    public GameObject[] blueBubbles;
    public GameObject[] pinkBubbles;
    public GameObject[] greenBubbles;

    public Text losingText;
    public Text winningText;

    [SerializeField]
    private bool[] blueBubblesFinished;

    [SerializeField]
    private bool[] pinkBubblesFinished;

    [SerializeField]
    private bool[] greenBubblesFinished;

    public Babybottle babyBottleScript;
    public playAnimationOnClick playAnimationOnClickScript;
    public ArrowClass arrowScript;
    public bool isFirstBubblePopped;



    // Use this for initialization
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



    }

    void showBubbles()
    {
        if (timer > 3 && blueBubblesFinished[0] == false)
        {
            arrowScript.isTimeToActivate = true;
            blueBubbles[0].SetActive(true);
        }

        if (timer > 4 && blueBubblesFinished[1] == false && isFirstBubblePopped)
        {
            blueBubbles[1].SetActive(true);
        }

        if (timer > 6 && pinkBubblesFinished[0] == false && isFirstBubblePopped)
        {
            pinkBubbles[0].SetActive(true);
        }

        if (timer > 8 && blueBubblesFinished[2] == false && isFirstBubblePopped)
        {
            blueBubbles[2].SetActive(true);
        }

        if (timer > 9 && pinkBubblesFinished[1] == false && isFirstBubblePopped)
        {
            pinkBubbles[1].SetActive(true);
        }

        if (timer > 10 && pinkBubblesFinished[2] == false && isFirstBubblePopped)
        {
            pinkBubbles[2].SetActive(true);
        }
    }

    void startTimer()
    {
        if (timer < 3 || (timer > 3 && isFirstBubblePopped) )
            timer += Time.deltaTime;

        // Debug.Log("Time: " + timer);
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

    void hideAllBubbleAtStart()
    {
        for (int i = 0; i < blueBubbles.Length; i++)
        {
            blueBubbles[i].SetActive(false);
        }

        for (int i = 0; i < pinkBubbles.Length; i++)
        {
            pinkBubbles[i].SetActive(false);
        }

        for (int i = 0; i < greenBubbles.Length; i++)
        {
            greenBubbles[i].SetActive(false);
        }
    }

    void hideAllText()
    {
        losingText.enabled = false;
        winningText.enabled = false;
    }

    public void setTrueTheNthBlueBubble(int n)
    {
        blueBubblesFinished[n] = true;
    }

    public void setTrueTheNthPinkBubble(int n)
    {
        pinkBubblesFinished[n] = true;
    }

    public void setTrueTheNthGreenBubble(int n)
    {
        greenBubblesFinished[n] = true;
    }

    //public GameObject getNthGreenBubble(int n)
    //{
    //    return blueBubbles[n];
    //}

    //public GameObject getNthPinkBubble(int n)
    //{
    //    return pinkBubbles[n];
    //}

    //public GameObject getNthBlueBubble(int n)
    //{
    //    return blueBubbles[n];
    //}

    public bool checkLostGame()
    {
        int unpoppedBlueBubbles = 0;
        int unpoppedPinkBubbles = 0;
        int unpoppedGreenBubbles = 0;

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

        if (unpoppedBlueBubbles + unpoppedPinkBubbles + unpoppedGreenBubbles >= 3)
        {
            return true;
        }

        return false;
    }

    public void gameOver()
    {
        babyBottleScript.gameOver = true;
        playAnimationOnClickScript.gameOver = true;
        Destroy(playAnimationOnClickScript.simleyObject);  
        Debug.Log("game OVER");
        Time.timeScale = 0;
        timer = 0;
        hideAllBubbleAtStart();
        losingText.enabled = true;

    }
    
    public bool checkGameWon()
    {
        if (babyBottleScript.gameWon)
            return true;

        return false;
    }

    public void gameWon()
    {
       
        winningText.enabled = true;
        hideAllBubbleAtStart();
    }

    
}