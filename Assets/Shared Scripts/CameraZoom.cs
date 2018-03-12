using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {


	public float duration = 1.0f;
	private float elapsed = 0.0f;
	private bool transitionForZoomIn = false;
	private bool transitionForZoomOut = false;


	// Update is called once per frame
	void Update () {
		if (transitionForZoomIn) {
			elapsed += Time.deltaTime ;
			Camera.main.orthographicSize = Mathf.SmoothStep(124f, 34f, elapsed);

			if (elapsed > 1.0f) {
				transitionForZoomIn = false;
				elapsed = 0.0f;
			}
		}

		if (transitionForZoomOut) {
			elapsed += Time.deltaTime ;
			Camera.main.orthographicSize = Mathf.SmoothStep(34f, 124f, elapsed);

			if (elapsed > 1.0f) {
				transitionForZoomOut = false;
				elapsed = 0.0f;

			}
		}
		
	}

	public void zoomIn(){
		transitionForZoomIn = true;
	}


	public void zoomOut(){
		transitionForZoomOut = true;
	}

}
