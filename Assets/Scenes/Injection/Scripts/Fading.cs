using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

	/// <summary>
	/// move to the next scene (success is displayed)
	/// </summary>

	public void moveToNextScene(){
		if (SceneManager.GetActiveScene ().name == "CremeApplication") {
			Application.LoadLevel(9);

		}else if(SceneManager.GetActiveScene ().name == "InjectionBaby"){
			Application.LoadLevel(10);

		}

	}
}
