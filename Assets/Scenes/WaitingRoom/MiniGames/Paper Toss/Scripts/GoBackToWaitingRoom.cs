using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackToWaitingRoom : MonoBehaviour {
	
	public void goBack(int sceneToGoTo){
		SceneManager.LoadScene(sceneToGoTo);
	}

}