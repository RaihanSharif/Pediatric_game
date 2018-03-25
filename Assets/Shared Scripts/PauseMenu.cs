﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	//Flag to keep track if game is paused
	public static bool isPaused;

	//Reference to the menu panel that will have to be toggled 
	public GameObject pauseMenuUI;

	//Constant for the scene number of the main menu
	public const string MENUSCENE = "MainMenu";

	void Awake(){
		isPaused = false;
	}

	/// <summary>
	/// Pauses the game by freezing game time and enables the pause menu
 	/// </summary>
	public void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isPaused = true;
	}

	/// <summary>
	/// Resumes the game by unfreezing game time and disables the pause menu
 	/// </summary>
	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		isPaused = false;
	}

	/// <summary>
	/// Loads the menu scene, defined in MENUSCENE constant and unfreezes game time
 	/// </summary>
	public void RestartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene(MENUSCENE);

     	int numberOfScenes = SceneManager.sceneCount;
     	for (int i = 0; i < numberOfScenes; i++) {
	        Scene scene = SceneManager.GetSceneAt(i);
	        if (scene.name != MENUSCENE) {
	            SceneManager.UnloadSceneAsync(scene);
	        }
     	}
	}

	public void RestartLevel(){
		Time.timeScale = 1f;
		Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene (loadedLevel.buildIndex);
	}

	/// <summary>
	/// Quits the game. Functional only once deployed
 	/// </summary>
	public void ExitGame(){
		Application.Quit();
	}

}