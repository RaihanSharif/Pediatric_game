using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : MonoBehaviour {

	public bool resize = true;
	private float timeCounter = 0.0f;
	private int timeInteger = 0;
	SpriteRenderer m_SpriteRenderer;
	public Animator anim;
	public bool isAnimationFinished;

	// Use this for initialization
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();
		isAnimationFinished = false;

	}


	// Update is called once per frame
	void Update () {
		if(resize == true) {
			if (timeInteger % 2 == 0) {
				//m_SpriteRenderer.color = Color.blue;
				transform.localScale += new Vector3(0.01F, 0, 0);
			}else {
				//m_SpriteRenderer.color = Color.white;
				transform.localScale -= new Vector3(0.01F, 0, 0);
			}
		}
		timeCounter += Time.deltaTime;
		timeInteger = (int)timeCounter;
	}



	public void OnMouseDown(){
		resize = false;	
	}


	public void SetAnimationToFinished(){
		
		//isAnimationFinished = true;
//		anim.enabled = false;
//		Debug.Log ("injection completed");
	}




}
