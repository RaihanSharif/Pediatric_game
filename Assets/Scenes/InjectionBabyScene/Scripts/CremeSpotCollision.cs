using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeSpotCollision : MonoBehaviour {

	public Arm arm;
	public SpriteRenderer m_SpriteRenderer;
	private float timeCounter = 0.0f;
	public Syringe syringe;
	public Star star;
	public Star star2;
	public bool inCollision;
	public Sprite spriteToRenderWhenExit;


	void Start(){
		inCollision = false;
	
	}

	void Update(){
//		if (syringe.isAnimationFinished == true) {
//			Debug.Log ("asasasas");
//			syringe.anim.enabled = false;
//		}

		if (inCollision == true) {
			timeCounter += Time.deltaTime;

			if (timeCounter > 6.0) {

				if (this.tag == "CremeSpot1") {

					syringe.anim.enabled = false;
					Debug.Log (timeCounter);

					Debug.Log ("cremespot1");
					//syringe.SetAnimationToFinished ();
					timeCounter = 0.0f;
					arm.startProcess ();
					this.GetComponent<SpriteRenderer>().enabled = false;
					this.GetComponent<PolygonCollider2D>().enabled = false;
					star.anim.SetTrigger("Active");
					syringe.anim.enabled = false;
					inCollision = false;

				}else if(this.tag == "CremeSpot2"){
					Debug.Log (timeCounter);

					Debug.Log ("cremespot2");
					syringe.anim.Play ("Idle");

					//syringe.SetAnimationToFinished ();
					timeCounter = 0.0f;
					arm.startProcess ();
					this.GetComponent<SpriteRenderer>().enabled = false;
					this.GetComponent<PolygonCollider2D>().enabled = false;
					star2.anim.SetTrigger("Active");
					syringe.anim.enabled = false;
					inCollision = false;

				}

			}
		}
			
		
	}




//	void OnCollisionEnter2D(Collision2D coll) {		
//
//		Debug.Log("collision ");
//
//		if (coll.gameObject.tag == "CremeTube") {
//			if (m_SpriteRenderer.color == Color.black) {
//				arm.startProcess ();
//				m_SpriteRenderer.color = Color.magenta;
//
//			}
//		}
//
//		if (coll.gameObject.tag == "Syringe") {
//			if (m_SpriteRenderer.color == Color.magenta) {
//				arm.startProcess ();
//				m_SpriteRenderer.color = Color.white;
//
//			}
//		}
//	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.GetType () == typeof(PolygonCollider2D)) {

			Debug.Log ("isHere");
			syringe.anim.enabled = true;
			syringe.anim.Play("SyringeAnimation");
			inCollision = true;
			timeCounter += Time.deltaTime;
			//Debug.Log ("time = " + timeCounter);

		}
	}


	void OnTriggerExit2D(Collider2D other){

		if (other.GetType () == typeof(PolygonCollider2D)) {


			timeCounter = 0.0f;
			inCollision = false;
			//syringe.anim.enabled = false;
			syringe.m_SpriteRenderer.sprite = spriteToRenderWhenExit;
			//syringe.anim.enabled = false;
			//Debug.Log ("exited");
			syringe.anim.Play ("Idle");
			syringe.anim.enabled = false;


		}



	}



}
