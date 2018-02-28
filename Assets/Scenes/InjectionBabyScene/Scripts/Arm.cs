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


	public bool firstStepIsDone = false;

	public Slider progressBar;


	// Use this for initialization
	void Start () {
		CreamMaxProgress = 6f;
		CreamCurrentProgress = 0f;    //initially current cream progress is going to be 0 because no spots have been covered

	}

	// Update is called once per frame
	void Update () {
		// updating the value of the slider here so maybe it won't break testing
		progressBar.value = CalculateProgress();
//		if (cremeTube.intersect(syringe){
//			Debug.Log("amine")
//		}

		if (completed == true) {
			timeCounter += Time.deltaTime;

			if (timeCounter > 3.0){
				fadeOut.SetTrigger("FadeOut");
			}
		}

	}

	/// <summary>
	/// pass the progress offset you want to increment the 
	/// progress bar by and increment it every time the button
	/// x is pressed
	/// </summary>
	/// <param name="progressOffset">the offset by which the current progress is increased</param>
	void IncreaseProgress(int progressOffset)
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
		Debug.Log("You did it bro");
		completed = true;

	}

	/// <summary>
	/// Increase the progress of the progress bar every time the button is clicked
	/// </summary>
	public void startProcess()
	{
//		(if syringe.position about the same as button...
		IncreaseProgress (ProgressOffset);
	}



}