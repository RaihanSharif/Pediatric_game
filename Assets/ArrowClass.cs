using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowClass : MonoBehaviour {

    public bool isTimeToActivate;
    public Renderer renderer;
    public Bubble bubbleScript;

    // Use this for initialization
    void Start () {
        hideArrow();
    }
	
	// Update is called once per frame
	void Update () {
        if (isTimeToActivate)
            revealArrow();
        if(bubbleScript.isFirstBubblePopped)
            hideArrow();
	}

    void hideArrow()
    {
        renderer.enabled = false;
    }

    void revealArrow()
    {
        renderer.enabled = true;
    }
}
