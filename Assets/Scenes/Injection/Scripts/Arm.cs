using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class Arm : MonoBehaviour {

	public float CreamCurrentProgress;   //corresponds to number of spots the creame has been applied to
	public float CreamMaxProgress;      //corresponds to maximum number of spots the cream can been applied to
	public int ProgressOffset = 3;   //the offset by which the progressbar will be increased
	private float timeCounter = 0.0f;
	private bool completed = false;
	public Animator fadeOut;
	public Slider progressBar;
	public CameraZoom cameraZoom;
	public bool callZoomOnce = false;
	public Sprite motherAndChildSmiling;

	public AudioCremeApplication theAudio;


	// Use this for initialization
	void Start () {
		CreamMaxProgress = 6f; // when the creamMaxProgress is reached, the game is completed
		CreamCurrentProgress = 0f;    //initially current cream progress is going to be 0 because no spots have been covered

	}

	// Update is called once per frame
	void Update () {

		if (completed == true) {
			timeCounter += Time.deltaTime;

			if (timeCounter > 5) {
				fadeOut.SetTrigger ("fadeOutEnd");
			}else if (callZoomOnce == false && timeCounter > 1.5){
				cameraZoom.zoomOut();
				theAudio.playSuccess();
				callZoomOnce = true;
				this.GetComponent<SpriteRenderer> ().sprite = motherAndChildSmiling;

			}
		}

	}

	/// <summary>
	/// pass the progress offset you want to increment the 
	/// progress bar by and increment it every time the button
	/// x is pressed
	/// </summary>
	/// <param name="progressOffset">the offset by which the current progress is increased</param>
	public void IncreaseProgress(int progressOffset)
	{
		CreamCurrentProgress += progressOffset;
//		progressBar.value = CalculateProgress();

		if (CreamCurrentProgress >= CreamMaxProgress)
		{
			CompleteScene();
		}
	}

	/// <summary>
	/// since the progress bar is from a range of 0 to 1
	/// it calculates the the ratio of the current progress 
	/// to the maximum progress of the bar
	/// </summary>
	/// <returns>return the ratio of the current progress to the max progress</returns>
	float CalculateProgress()
	{
		return CreamCurrentProgress / CreamMaxProgress;
	}

	/// <summary>
	/// equate  the current cream progress to the maximum cream progress
	/// and output that you've completed the scene the game
	/// </summary>
	void CompleteScene()
	{
		CreamCurrentProgress = CreamMaxProgress;
		completed = true;

	}

	/// <summary>
	/// Increase the progress of the progress bar every time the button is clicked
	/// </summary>
	public void startProcess()
	{
//		if syringe.position about the same as button...
		IncreaseProgress (ProgressOffset);
	}

	/// <summary>
	/// Check if game is completed or not 
	/// </summary>
	/// <returns><c>true</c>, if completed was gotten, <c>false</c> otherwise.</returns>
	public bool getCompleted()
	{
		return completed;
	}




}