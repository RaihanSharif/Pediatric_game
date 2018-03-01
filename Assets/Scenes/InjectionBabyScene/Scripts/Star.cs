using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {

	public Animator anim;
	public SpriteRenderer plaster; // plaster displayed when the injection of the first creme spot is completed
	public SpriteRenderer plaster2; // plaster displayed when the injection of the first creme spot is completed

	/// <summary>
	/// Shows the 1st plaster and remove the star sprite on creme spot 1.
	/// </summary>
	public void showPlasterAndRemoveStar(){
		this.GetComponent<SpriteRenderer>().enabled = false;
		plaster.enabled = true;

	}

	/// <summary>
	/// Shows the 1st plaster and remove the star sprite on creme spot 2
	/// </summary>
	public void showPlasterAndRemoveStar2(){
		this.GetComponent<SpriteRenderer>().enabled = false;
		plaster2.enabled = true;


	}
}
