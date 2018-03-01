using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeSpotCollision : MonoBehaviour {

	public Arm arm;
	public SpriteRenderer m_SpriteRenderer; // sprite renderer of the Cremespot
	private float timeCounter = 0.0f; // counter to make sure the injection lasts for a specific amount of time 
	public Syringe syringe;
	public Star star;
	public Star star2;
	public bool inCollision = false; // to check whether the Creme spot is in collision with another object
	public Sprite spriteToRenderWhenExit; // when the injection is done, we replace the empty syringe with the filled one  



	void Update(){

		doUpdate ();		
	}

	void doUpdate(){

		if (inCollision == true) {
			timeCounter += Time.deltaTime;

			if (timeCounter > 6.0) { // if the injection lasts more than 6.0 seconds, then it is completed
				// if injection is completed for creme spot 1, then follow this process
				if (this.tag == "CremeSpot1") {
					injectionIsDone (star);
				// if injection is completed for creme spot 2, then follow this process
				}else if(this.tag == "CremeSpot2"){
					injectionIsDone (star2);
				}
			}
		}

	}

	/// <summary>
	/// process to follow when the injection is done for one creme spot.
	/// </summary>
	/// <param name="theStar">star for which animation will be triggered</param>
	void injectionIsDone(Star theStar){

		timeCounter = 0.0f;// reset the time counter
		arm.startProcess ();// update the slider
		this.GetComponent<SpriteRenderer>().enabled = false; // make the creme spot disappear
		this.GetComponent<PolygonCollider2D>().enabled = false; // remove the creme spot collider
		theStar.anim.SetTrigger("Active"); // trigger the star animation creme spot 
		syringe.anim.enabled = false; // stop the syringe animation
		inCollision = false; // the creme spot is no more in collision now 
		

	}


	/// <summary>
	/// Plays the syringe animation ( emptying the syringe step by step )
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerStay2D(Collider2D other) {
		if (other.GetType () == typeof(PolygonCollider2D)) { // if the creme spot is in collision with a polygon collider (syringe needle)

			syringe.anim.enabled = true; // enable the syringe animation
			syringe.anim.Play("SyringeAnimation"); // play the syringe animation
			inCollision = true; // the creme spot is now in collison with the other object 
			timeCounter += Time.deltaTime; // increase the time counter

		}
	}

	/// <summary>
	/// refill the syringe when it exits the creme spot
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerExit2D(Collider2D other){

		if (other.GetType () == typeof(PolygonCollider2D)) { // if the creme spot is in collision with a polygon collider (syringe needle)


			timeCounter = 0.0f; // reset the time counter
			inCollision = false; // increase the time counter
			syringe.m_SpriteRenderer.sprite = spriteToRenderWhenExit; // change the sprite renderer to show that the syringe is filled  
			syringe.anim.Play ("Idle"); // come back to first state of syringe animation
			syringe.anim.enabled = false; // disable the syringe animation 


		}



	}



}
