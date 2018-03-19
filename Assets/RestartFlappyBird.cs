using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartFlappyBird : MonoBehaviour {


	/// <summary>
	/// make the restart button non functional 
	/// </summary>
	void OnMouseDown(){
		SceneManager.LoadScene("FlappyBird");
		this.GetComponent<GameObject> ().SetActive (false);
	}
}
