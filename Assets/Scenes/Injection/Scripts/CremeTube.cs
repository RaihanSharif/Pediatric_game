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


	// Use this for initialization
	void Start () {
		
		m_SpriteRenderer = GetComponent<SpriteRenderer>();

	}





}
