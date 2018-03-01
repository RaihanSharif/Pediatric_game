using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeTube : MonoBehaviour {


	public bool resize = true; // boolean variabe used to check whether the creme tube movement should be disabled
	private SpriteRenderer m_SpriteRenderer;
	private float timeCounter = 0.0f;
	private int timeInteger = 0;


	// Use this for initialization
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update () {

		if(resize == true) {

			if (timeInteger % 2 == 0) {
				transform.localScale += new Vector3(0.01F, 0, 0); // make it rotate in one direction 
			}else {
				transform.localScale -= new Vector3(0.01F, 0, 0);// make it rotate in one direction 
			}
		}

		timeCounter += Time.deltaTime;
		timeInteger = (int)(timeCounter);

	}
	/// <summary>
	/// when the creme tube is clicked, the creme tube movement stops 
	/// </summary>
	public void OnMouseDown(){
		resize = false;
	}



}
