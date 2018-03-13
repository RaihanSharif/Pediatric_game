using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideBottleBg : MonoBehaviour {

    float timer = 0.0f;
    public Renderer rend;
    
    // Update is called once per frame
    void Update ()
    {
        startTimer();
        hidebgImage();
    }   

    void startTimer()
    {
        timer += Time.deltaTime;
    }

    /// <summary>
    /// hides the background of the bottle after 2 seconds 
    /// </summary>
    void hidebgImage()
    {
        if (timer > 2)
        {
            rend.enabled = false;
        }
    }


}
