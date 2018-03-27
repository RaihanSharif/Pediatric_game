using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpoon : MonoBehaviour {

    public float timer = 0.0f;
    public GameObject tutorialSpoon;
    public DragAndDrop spoonScript;

    /// <summary>
    /// this is being called in the update where we start a timer
    /// </summary>
    void runTimer()
    {
        timer += Time.deltaTime;

    }

    /// <summary>
    /// if the timer is more than 8 seconds then hide the tutorial spoon and reveal the games spoon 
    /// </summary>
    void Update ()
    {
        runTimer();
        if (timer > 8)
        {
            tutorialSpoon.SetActive(false);
            spoonScript.spoon.SetActive(true);
        }

    }
}
