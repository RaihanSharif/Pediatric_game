using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smiley : MonoBehaviour {

	public Animator anim;
	public SpriteRenderer plaster; // plaster displayed when the injection of the first creme spot is completed
	public SpriteRenderer plaster2; // plaster displayed when the injection of the first creme spot is completed

	/// <summary>
	/// Remove smiley and make plaster visible
	/// </summary>
	public void showPlasterAndRemoveStar(AnimationEvent animationEvent){
		this.GetComponent<SpriteRenderer>().enabled = false; //make the smiley disappear
		string thePlasterName = animationEvent.stringParameter; // get the name of plaster that has to to show up 

		// make the corresponding plaster visible
		if(thePlasterName == "plaster"){
			plaster.enabled = true;
		}else if(thePlasterName == "plaster2"){
			plaster2.enabled = true;
		}

	}
		
}
