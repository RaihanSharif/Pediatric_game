using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngBabyIntegrationTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
		
	/// <summary>
	/// Baby drinks all the menu and moves to main menu
	/// </summary>
	[UnityTest]
	public IEnumerator BabyDrinksAllAndMovesToMainMenuPasses() {
		LoadSceneByName ("IngestionBaby");
		yield return null;


	}

	/// <summary>
	/// Baby drinks all the milk and moves on to the next scene
	/// </summary>
	[UnityTest]
	public IEnumerator BabyDrinksAllAndMovesToWaitingRoomPasses() {
		LoadSceneByName ("IngestionBaby");
		yield return null;


	}
}
