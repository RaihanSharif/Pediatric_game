using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComeBackSprite : MonoBehaviour {


	/// <summary>
	/// Go back to waiting room when button is clicked 
	/// </summary>
	void OnMouseDown(){
		goBackToWaitingRoom();
		disableBackButton();
	}

	/// <summary>
	/// Gos the back to waiting room.
	/// </summary>
	public void goBackToWaitingRoom(){
		SceneManager.LoadScene("WaitingRoom");
	}

	/// <summary>
	/// Disables the go back button.
	/// </summary>
	public void disableBackButton(){
		this.GetComponent<GameObject> ().SetActive (false);
	}
}
