using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBallBehaviour : MonoBehaviour {

	Vector2 startPos, endPos, direction;
	float swipeTimeStart, swipeTimeEnd, timeInterval;

	[Range (0.05f, 1f)] public float throwForce = 0.3f;

	void Update() {

		// At the start of the swipe
		if (Input.touchCount > 0 && Input.GetTouch(0).phase==TouchPhase.Began) {
			swipeTimeStart = Time.time;
			startPos = Input.GetTouch(0).position; // start position is where the touch happened
		}

		// At the end of the swipe
		if (Input.touchCount > 0 && Input.GetTouch (0).phase==TouchPhase.Ended) {
			swipeTimeEnd = Time.time;
			timeInterval = swipeTimeEnd - swipeTimeStart;
			endPos = Input.GetTouch(0).position;
			direction = startPos - endPos;
			GetComponent<Rigidbody2D>().AddForce(-direction / timeInterval * throwForce);
		}

	}

}