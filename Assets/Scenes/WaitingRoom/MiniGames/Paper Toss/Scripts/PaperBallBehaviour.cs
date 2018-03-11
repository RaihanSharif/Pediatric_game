using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBallBehaviour : MonoBehaviour {

	Vector2 startPos, endPos, direction;
	float swipeTimeStart, swipeTimeEnd, timeInterval;

	[Range (0.05f, 1f)] public float throwForce = 0.3f;

	int touchIndex = 0; // used to access a specific touch if there have been multiple ones. In this case the index is 0 because there will only be 1 touch.

	void Update() {
		calculateSwipe();
	}

	/// <summary>
	/// Checks if it is in the beginning of a swipe or the of a swipe. 
	/// If it is in the beginning, it records the time that the screen was first pressed and the position.
	/// If it is in the end, then it uses the current time and position along with the recorded start time and position
	/// to know the swipe direction and how long the swipe took.
	/// </summary>
	void calculateSwipe(){

		// Start of the swipe
		if (Input.touchCount > 0 && Input.GetTouch(touchIndex).phase == TouchPhase.Began) {
			swipeTimeStart = Time.time;
			startPos = Input.GetTouch(touchIndex).position; // start position is where the touch happened
		}

		// End of the swipe
		if (Input.touchCount > 0 && Input.GetTouch(touchIndex).phase == TouchPhase.Ended) {
			swipeTimeEnd = Time.time;
			timeInterval = swipeTimeEnd - swipeTimeStart;
			endPos = Input.GetTouch(touchIndex).position; // end position is where the finger was released from the screen
			direction = startPos - endPos;
			GetComponent<Rigidbody2D>().AddForce(-direction / timeInterval * throwForce); // adds a force to the paper ball based on the direction and time of the swipe and the throw force, which is a constant
		}

	}

}