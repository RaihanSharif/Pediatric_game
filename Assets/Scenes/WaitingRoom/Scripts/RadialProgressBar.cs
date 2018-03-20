﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressBar : MonoBehaviour {
    public Transform LoadingBar;    //variable for filling loading bar
    public Transform TextTimeLeft;   //represents the "TimeLeft..." text in the center
    public Image loadingBarImage;   //image of the loading bar in the canvas   

    [SerializeField]
    private LevelFinishedMenu lvlFM;

    [SerializeField]
    private float currentBarAmount = 100f;    

    [SerializeField]
    private float speed = 1f;
    private float MaxBarAmount = 100f;

    private int MINIMUMVALUE = 0;  //ending time for gauge
    private int REDZONEVALUE = 60;   //time below which loading bar becomes red
    private int DECREASEBARAMOUNT = 34;

    [SerializeField]
    private bool decreaseBar = false;

    // Update is called once per frame
    void Update () {
        doUpdate();
	}

    void doUpdate()
    {
        if (timeStillRemaining())
        {
            if (decreaseBar)
            {
                if (inRedZone())
                {
                    changeLoadingBarColorToRed();
                    decrementCurrentBarAmountBySpeed();
                }
                else
                {
                    decrementCurrentBarAmountBySpeed();
                }
            }
            updateLoadingBar();
        }
        else
        {
            lvlFM.OnLevelFinished();
        }

    }

    #region MethodsUsedInDoUpdate

    /// <summary>
    /// multiply speed by Time.deltaTime to move object by per second
    /// instead of by per frame
    /// </summary>
    void decrementCurrentBarAmountBySpeed()
    {
        currentBarAmount -= DECREASEBARAMOUNT;
        decreaseBar = false;
    }
    
    /// <summary>
    /// display the current time by converting the float
    /// value to a string and then setting the TextLoading 
    /// Game object to true
    /// </summary>
    /*void displayCurrentTimeAmountOnGauge()
    {
        TextIndicator.GetComponent<Text>().text = ((int)currentBarAmount).ToString() + "s";
        TextTimeLeft.gameObject.SetActive(true);
    } */

    /// <summary>
    /// set the loading text on the gauge to be false 
    /// and get the TextIndecator Transform to display the done text
    /// </summary>
   /* void displayDoneTextOnGauge()
    {
        TextTimeLeft.gameObject.SetActive(false);
        TextIndicator.GetComponent<Text>().text = "DONE!";
    }
    */

    void updateLoadingBar()
    {
        LoadingBar.GetComponent<Image>().fillAmount = currentBarAmount / 100;
    }

    void changeLoadingBarColorToRed()
    {
        loadingBarImage.GetComponent<Image>().color = new Color(255, 0, 0);

    }

    bool inRedZone()
    {
        return currentBarAmount <= REDZONEVALUE;
    }

    bool timeStillRemaining()
    {
        return currentBarAmount > MINIMUMVALUE;
    }
    #endregion

}
