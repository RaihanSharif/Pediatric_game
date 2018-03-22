using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartFlappyBird : MonoBehaviour {


	/// <summary>
	/// make the restart button non functional 
	/// </summary>
	void OnMouseDown(){
		disableRestartButton ();
		restartTheGame ();
	}
		

	/// <summary>
	/// Restarts the game.
	/// </summary>
	public void restartTheGame(){
		SceneManager.LoadScene("FlappyBird");
	}


	/// <summary>
	/// Disables the restart button.
	/// </summary>
	public void disableRestartButton(){
		this.GetComponent<GameObject>().SetActive(false);
	}
}
