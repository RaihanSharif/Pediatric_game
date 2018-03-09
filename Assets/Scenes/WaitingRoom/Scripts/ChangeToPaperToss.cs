using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToPaperToss : MonoBehaviour {

	public void changeToPaperToss(int sceneToChangeTo){
		SceneManager.LoadScene(sceneToChangeTo);
	}

}