using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	public Animator anim;
	public SpriteRenderer plaster;
	public SpriteRenderer plaster2;
	public Syringe syringe;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showPlasterAndRemoveStar(){
		this.GetComponent<SpriteRenderer>().enabled = false;
		plaster.enabled = true;
		//syringe.anim.Play("Idle");
//		syringe.anim.enabled = false;

	}


	public void showPlasterAndRemoveStar2(){
		this.GetComponent<SpriteRenderer>().enabled = false;
		plaster2.enabled = true;
		//syringe.anim.Play("Idle");
//		syringe.anim.enabled = false;

	}
}
