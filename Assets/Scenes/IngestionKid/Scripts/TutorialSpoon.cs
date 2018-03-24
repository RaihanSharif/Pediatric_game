using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpoon : MonoBehaviour {

    public float timer = 0.0f;
    public GameObject tutorialSpoon;
    public DragAndDrop spoonScript;

    // Use this for initialization
    void Start ()
    {
		
	}

    void runTimer()
    {
        timer += Time.deltaTime;

    }

    // Update is called once per frame
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
