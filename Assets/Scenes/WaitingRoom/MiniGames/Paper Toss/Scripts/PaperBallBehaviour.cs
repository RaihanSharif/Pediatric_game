using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBallBehaviour : MonoBehaviour {

	Vector2 swipeStartPos, 	// position in the screen where the swipe started
	swipeEndPos, 			// position in the screen where the swipe ended
	direction; 				// direction of the swipe

	float swipeStartTime, 	// time when the swipe started
	swipeEndTime, 			// time when the swipe ended
	timeInterval; 			// how long the swipe took

	[Range (0.05f, 1f)] public float throwForce = 0.3f; // value that is taken into account when calculating the total force applied to the paper ball

	int touchIndex = 0; // used to access a specific touch if there have been multiple ones. In this case the index is 0 because there will only be 1 touch

	void Update() {
		calculateSwipe();
	}

	/// <summary>
	/// Checks how many times the screen was tapped to see if there was any tap at all.
	/// </summary>
	bool wasThereATap(){
		int numOfTaps = Input.touchCount;
		return numOfTaps > 0;
	}

	/// <summary>
	/// Returns the current position of the swipe in the screen.
	/// </summary>
	Vector2 getSwipePos(){
		var currentSwipePos = Input.GetTouch(touchIndex).position;
		return currentSwipePos;
	}

	/// <summary>
	/// Returns the phase in which the swipe is.
	/// Beginning, end, etc...
	/// </summary>
	TouchPhase getSwipePhase(){
		var swipePhase = Input.GetTouch(touchIndex).phase;
		return swipePhase;
	}

	/// <summary>
	/// Checks if the swipe is in the beginning.
	/// </summary>
	bool isSwipeInTheBeginning(){
		var beginning = TouchPhase.Began;
		return getSwipePhase() == beginning;
	}

	/// <summary>
	/// Checks if the swipe is in the beginning.
	/// </summary>
	bool isSwipeInTheEnding(){
		var ending = TouchPhase.Ended;
		return getSwipePhase() == ending;
	}

	/// <summary>
	/// Sets the start position and time of the swipe.
	/// </summary>
	void setStartPosAndTime(){
		swipeStartPos = getSwipePos();
		swipeStartTime = Time.time;
	}

	/// <summary>
	/// Sets the end position and time of the swipe.
	/// </summary>
	void setEndPosAndTime(){
		swipeEndPos = getSwipePos();
		swipeEndTime = Time.time;
	}

	/// <summary>
	/// Calculates the force to be added to the paper ball.
	/// </summary>
	void calculatePaperBallForce(){
		timeInterval = swipeEndTime - swipeStartTime;
		direction = swipeStartPos - swipeEndPos;

		GetComponent<Rigidbody2D>().AddForce(-direction / timeInterval * throwForce);
	}

	/// <summary>
	/// Calculates the direction of the swipe and how long it took based on the starting and ending position and times of the swipe.
	/// This is then used to add a force to the paper ball so that it moves.
	/// </summary>
	void calculateSwipe(){

		if (wasThereATap() && isSwipeInTheBeginning()) {
			setStartPosAndTime();
		}

		if (wasThereATap() && isSwipeInTheEnding()) {
			setEndPosAndTime();
			calculatePaperBallForce();
		}

	}

}
