using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CremeTube : MonoBehaviour {


	public bool resize = true; // boolean variabe used to check whether the creme tube movement should be disabled
	private SpriteRenderer m_SpriteRenderer;
	private float timeCounter = 0.0f;
	private int timeInteger = 0;
	public Sprite openCremeTube;
	public Sprite closedCremeTube;

	public GameObject cremeSpot1; 
	public GameObject cremeSpot2;


	// Use this for initialization
	void Start () {

		disableAllColliders();
		this.GetComponent<Animator>().Play ("StartExplanation");
		m_SpriteRenderer = GetComponent<SpriteRenderer>();

	}


	public void disableAllColliders(){
		cremeSpot1.GetComponent<PolygonCollider2D> ().enabled = false;
		cremeSpot2.GetComponent<PolygonCollider2D> ().enabled = false;
		this.GetComponent<BoxCollider2D> ().enabled = false;
		this.GetComponent<PolygonCollider2D>().enabled = false;

	}



	public void enableCremeSpotColliders(){
		cremeSpot1.GetComponent<PolygonCollider2D> ().enabled = true;
		cremeSpot2.GetComponent<PolygonCollider2D> ().enabled = true;
		this.GetComponent<BoxCollider2D> ().enabled = true;
		this.GetComponent<PolygonCollider2D>().enabled = true;

	}





}
