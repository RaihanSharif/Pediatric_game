using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishedMenu : MonoBehaviour {
	private float counter;

	//Flag to keep track if level is finished
	public static bool isFinished = false;

	//Reference to the menu panel that will have to be toggled 
	[SerializeField]
	private GameObject levelFinishedMenuUI;

	[SerializeField]
	private static LevelFinishedMenu lvlFM;


	//Constant for the scene number of the main menu
	public const string MENUSCENE = "MainMenu";

	/// <summary>
	/// Pauses the game enables the level finished menu
 	/// </summary>
	public void OnLevelFinished(){
		if (counter > 0.1f) {
			levelFinishedMenuUI.SetActive (true);
			isFinished = true;
			counter = 0f;
		}
		counter += Time.deltaTime;
	}

	/// <summary>
	/// Loads the menu scene, defined in MENUSCENE constant and unfreezes game time
 	/// </summary>
	public void Restart(){
		Time.timeScale = 1f;
		SceneManager.LoadScene(MENUSCENE);
	}

	public void LoadNextScene(string nextScene){
		Time.timeScale = 1f;
		SceneManager.LoadScene(nextScene);
		WaitingRoomData.currentBarAmount = 100f;


	}
	

}
