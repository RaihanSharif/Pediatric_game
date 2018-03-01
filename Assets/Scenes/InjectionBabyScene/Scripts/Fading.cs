using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

	/// <summary>
	/// move to the next scene (success is displayed)
	/// </summary>
	public void moveToNextScene(){
		Application.LoadLevel(6);
	}
}
