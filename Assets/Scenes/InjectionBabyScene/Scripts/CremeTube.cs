using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeTube : MonoBehaviour {


	public bool resize = true;
	private float timeCounter = 0.0f;
	private int timeInteger = 0;
	private SpriteRenderer m_SpriteRenderer;


	// Use this for initialization
	void Start () {
		m_SpriteRenderer = GetComponent<SpriteRenderer>();

	}

	// Update is called once per frame
	void Update () {


		if(resize == true) {

			if (timeInteger % 2 == 0) {
				m_SpriteRenderer.color = Color.blue;
				transform.localScale += new Vector3(0.01F, 0, 0);
			}else {
				transform.localScale -= new Vector3(0.01F, 0, 0);
				m_SpriteRenderer.color = Color.white;
			}
			//transform.Rotate(new Vector3(0,0,1));
			//transform.Rotate (Vector3.right * 50 * Time.deltaTime, Space.World);
		}

		timeCounter += Time.deltaTime;
		timeInteger = (int)timeCounter;

	}

	public void OnMouseDown(){
		resize = false;
	}



}
