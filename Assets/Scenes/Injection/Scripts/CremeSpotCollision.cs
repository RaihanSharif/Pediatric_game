using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CremeSpotCollision : MonoBehaviour {

	public Arm arm;
	public SpriteRenderer m_SpriteRenderer; // sprite renderer of the Cremespot
	private float timeCounter = 0.0f; // counter to make sure the injection lasts for a specific amount of time 
	public Syringe syringe;
	public CremeTube cremeTube;
	public Smiley smiley;
	public Smiley smiley2;
	public bool inCollision = false; // to check whether the Creme spot is in collision with another object
	public Sprite spriteToRenderWhenExit; // when the injection is done, we replace the empty syringe with the filled one  

	public AudioCremeApplication theAudio;
	private int cremeCounter = 0;




	void Update(){

		doUpdate ();		
	}

	void doUpdate(){

		if (inCollision == true) {
			timeCounter += Time.deltaTime;

			if (timeCounter > 6.0) { // if the injection lasts more than 6.0 seconds, then it is completed
				
				// if injection is completed for creme spot 1, then follow this process
				if (this.tag == "CremeSpot1") {
					injectionIsDone (smiley);

				// if injection is completed for creme spot 2, then follow this process
				}else if(this.tag == "CremeSpot2"){
					injectionIsDone (smiley2);

					// if creme application is completed for creme spot 1, then follow this process
				}
			}
		}

	}

	/// <summary>
	/// process to follow when the injection is done for one creme spot.
	/// </summary>
	/// <param name="theStar">star for which animation will be triggered</param>
	public void injectionIsDone(Smiley theSmiley){

		theAudio.playSuccessForInjectionSpot();
		timeCounter = 0.0f;// reset the time counter
		arm.startProcess ();// update the slider
		this.GetComponent<SpriteRenderer>().enabled = false; // make the creme spot disappear
		this.GetComponent<PolygonCollider2D>().enabled = false; // remove the creme spot collider
		theSmiley.anim.SetTrigger("Active"); // trigger the star animation creme spot 
		syringe.anim.enabled = false; // stop the syringe animation
		inCollision = false; // the creme spot is no more in collision now 
		

	}


	/// <summary>
	/// Plays the syringe animation ( emptying the syringe step by step )
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay2D(Collider2D other) {

		if (other.GetType () == typeof(PolygonCollider2D) && other.tag == "Syringe") { // if the creme spot is in collision with a polygon collider (syringe needle)

			syringe.anim.enabled = true; // enable the syringe animation
			syringe.anim.Play("SyringeAnimation"); // play the syringe animation
			inCollision = true; // the creme spot is now in collison with the other object 
			timeCounter += Time.deltaTime; // increase the time counter

		}else if (other.GetType () == typeof(PolygonCollider2D) && other.tag == "CremeTube") { // if the creme spot is in collision with a polygon collider (syringe needle)

			playCremeSound();
			cremeCounter++;

			cremeTube.GetComponent<Animator> ().enabled = true;
			cremeTube.GetComponent<SpriteRenderer> ().sprite = cremeTube.openCremeTube;
			cremeTube.GetComponent<BoxCollider2D> ().enabled = false;
			if (this.tag == "CremeSpot1") {
				cremeTube.GetComponent<Animator>().Play("applyCremeOnSpot1");
				this.GetComponent<Animator> ().Play("CremeSpot1ChangeColor");

			}else if (this.tag == "CremeSpot2") {
				cremeTube.GetComponent<Animator>().Play("applyCremeOnSpot2");
				this.GetComponent<Animator>().Play("CremeSpot2ChangeColor");

			}
			//this.GetComponent<Animator>().SetTrigger("makeItWhite");
			//cremeTube.GetComponent<Animator>().enabled = true;


		}
	}


	public void playCremeSound(){
		if (cremeCounter % 60 == 0) {
			theAudio.playCremeOnSpot();
		}
	}


		

	/// <summary>
	/// refill the syringe when it exits the creme spot
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D(Collider2D other){

		if (other.GetType () == typeof(PolygonCollider2D) && other.tag == "Syringe") { // if the creme spot is in collision with a polygon collider (syringe needle)


			timeCounter = 0.0f; // reset the time counter
			inCollision = false; // increase the time counter
			syringe.m_SpriteRenderer.sprite = spriteToRenderWhenExit; // change the sprite renderer to show that the syringe is filled  
			syringe.anim.Play ("Idle"); // come back to first state of syringe animation
			syringe.anim.enabled = false; // disable the syringe animation 


		}else if(other.GetType () == typeof(PolygonCollider2D) && other.tag == "CremeTube"){


			//cremeTube.GetComponent<SpriteRenderer> ().sprite = cremeTube.closedCremeTube;
			//this.GetComponent<SpriteRenderer>().color = Color.grey;
			this.GetComponent<Animator>().Play("Idle");
			//this.GetComponent<Animator> ().ResetTrigger("makeItWhite");
			cremeTube.GetComponent<Animator>().enabled = false;

		}

	}


	void finishCremeApplication(){

		
		theAudio.playCremeSpotBecomesWhite();
		this.GetComponent<Animator>().enabled = false;
		this.GetComponent<PolygonCollider2D>().enabled = false;
		cremeTube.GetComponent<BoxCollider2D> ().enabled = true;
		cremeTube.GetComponent<Animator> ().enabled = false;
		cremeTube.GetComponent<SpriteRenderer>().sprite = spriteToRenderWhenExit;
		arm.startProcess();// update the slider


	}



}
