using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClockAnimator : MonoBehaviour {

    public Transform hours, minutes, seconds;   //variables to move the hours, minutes and seconds hands on the clock

    private const float
        hoursToDegrees = 360f / 12f,
        minutesToDegrees = 360f / 60f,
        secondsToDegrees = 360f / 60f;
	
	// Update is called once per frame
	void Update () {

        doUpdate();

    }

    void doUpdate()
    {
        DateTime currentTime = getCurrentTime();
        rotateHoursHand(currentTime);
        rotateMinutesHand(currentTime);
        rotateSecondsHand(currentTime);

    }

    /// <summary>
    /// gets current time according to GMT
    /// </summary>
    /// <returns>returns the Time</returns>
    DateTime getCurrentTime()
    {
        return DateTime.Now;
    }

    #region Rotation of hands on clock

    void rotateHoursHand(DateTime time)
    {
        hours.localRotation = Quaternion.Euler(0f, 0f, time.Hour * -hoursToDegrees);
    }

    void rotateMinutesHand(DateTime time)
    {
        minutes.localRotation = Quaternion.Euler(0f, 0f, time.Minute * -minutesToDegrees);
    }

    void rotateSecondsHand(DateTime time)
    {
        seconds.localRotation = Quaternion.Euler(0f, 0f, time.Second * -secondsToDegrees);
    }

    #endregion
}
