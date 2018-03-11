using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToWaitingRoom : MonoBehaviour {

	/// <summary>
	/// When called, this function loads the scene represented by the integer parameter provided.
	/// In this case it provides a transition to the main waiting room scene.
	/// </summary>
	/// <param name="sceneToChangeTo">Scene to change to.</param>
	public void goBack(int sceneToGoTo){
		SceneManager.LoadScene(sceneToGoTo);
	}

}