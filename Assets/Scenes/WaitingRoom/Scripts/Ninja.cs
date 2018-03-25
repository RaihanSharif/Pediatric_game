using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {


	public WaitingRoomSounds roomSounds;


	/// <summary>
	/// Play Ninja Attack animation
	/// </summary>
	public void Attack(){
		GetComponent<Animator> ().Play ("NinjaAttack");
	}

	/// <summary>
	/// plays the ninja sound.
	/// </summary>
	public void playNinjaSound(){
		roomSounds.playNinja ();
	}


	/// <summary>
	/// Raises the mouse down event.
	/// </summary>
	public void OnMouseDown(){
		Attack ();
	}
}
