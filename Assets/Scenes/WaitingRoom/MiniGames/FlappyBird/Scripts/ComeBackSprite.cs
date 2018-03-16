using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComeBackSprite : MonoBehaviour {


	/// <summary>
	/// Go back to waiting room when button is clicked 
	/// </summary>
	void OnMouseDown(){
		SceneManager.LoadScene("WaitingRoom");
		this.GetComponent<GameObject> ().SetActive (false);

	}
}
