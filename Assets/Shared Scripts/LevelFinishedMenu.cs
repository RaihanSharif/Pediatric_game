﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinishedMenu : MonoBehaviour {

	//Flag to keep track if level is finished
	public static bool isFinished = false;

	//Reference to the menu panel that will have to be toggled 
	public GameObject levelFinishedMenuUI;

	//Constant for the scene number of the main menu
	public const string MENUSCENE = "MainMenu";

	/// <summary>
	/// Pauses the game by freezing game time and enables the level finished menu
 	/// </summary>
	public void OnLevelFinished(){
		levelFinishedMenuUI.SetActive(true);
		Time.timeScale = 0f;
		isFinished = true;
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
	}
	

}
