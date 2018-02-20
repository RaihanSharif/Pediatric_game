using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeSpotCollision : MonoBehaviour {

	public Arm arm;
	public SpriteRenderer m_SpriteRenderer;


	void OnCollisionEnter2D(Collision2D coll) {		

		Debug.Log("collision ");

		if (coll.gameObject.tag == "CremeTube") {
			if (m_SpriteRenderer.color == Color.black) {
				arm.startProcess ();
				m_SpriteRenderer.color = Color.magenta;

			}
		}

		if (coll.gameObject.tag == "Syringe") {
			if (m_SpriteRenderer.color == Color.magenta) {
				arm.startProcess ();
				m_SpriteRenderer.color = Color.white;

			}
		}


	}
}
