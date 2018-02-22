using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeSpotCollision : MonoBehaviour {

	public Arm arm;
	public SpriteRenderer m_SpriteRenderer;
	private float timeCounter = 0.0f;
	private int timeInteger = 0;
	public Syringe syringe;


	void Start(){
	}

	void Update(){
		if (syringe.isAnimationFinished == true) {
			syringe.anim.enabled = false;
			//Debug.Log ("");
			//animation for success
			//Animator.Play(state, layer, normalizedTime);
			//syringe.anim.StartPlayback;
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
		syringe.anim.enabled = true;
				
			timeCounter += Time.deltaTime;
			timeInteger = (int)timeCounter;

	}


	void OnTriggerExit2D(Collider2D other){
		Debug.Log ("trigger exit works");
		syringe.anim.enabled = false;
	}


//	void OnCollisionStay2D(Collision2D coll) {
//
//		if (timeInteger <= 13) {
//			syringeAnim.enabled = true;
//
//		}
//			
//		timeCounter += Time.deltaTime;
//		timeInteger = (int)timeCounter;
//	}
//
//
//	void OnCollisionExit2D(Collision2D coll) {
//		syringeAnim.enabled = false;
//	}
}
