using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour {

	public bool resize = true;
	public SpriteRenderer m_SpriteRenderer;
	public Animator anim;
	private float timeCounter = 0.0f; // to keep track of how long a process should be executed
	private int timeInteger; // integer rounded value of timeCounter



	// Update is called once per frame
	void Update () {
		if(resize == true) {
			if (timeInteger % 2 == 0) { // we use time integer here to check whether the rounded value of timeCounter is even or odd
				transform.localScale += new Vector3(0.0002F, 0, 0);// make it rotate in one direction 
			}else {
				transform.localScale -= new Vector3(0.0002F, 0, 0);// make it rotate in one direction 
			}
		}

		timeCounter += Time.deltaTime;
		timeInteger = (int)(timeCounter);
	}

	/// <summary>
	/// when the syringe is clicked, the syringe movement stops 
	/// </summary>
	public void OnMouseDown(){
		resize = false;	
	}
		




}
