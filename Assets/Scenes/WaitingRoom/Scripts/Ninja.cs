using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {

	/// <summary>
	/// Play Ninja Attack animation
	/// </summary>
	public void Attack(){
		GetComponent<Animator> ().Play ("NinjaAttack");
	}


	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	public void OnMouseDown(){
		Attack ();
	}
}
