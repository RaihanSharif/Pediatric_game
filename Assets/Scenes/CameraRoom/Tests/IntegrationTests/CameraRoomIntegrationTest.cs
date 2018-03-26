using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraRoomIntegrationTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	[UnityTest]
	public IEnumerator CameraRoomCanRestartLevelPasses() {
		LoadSceneByName ("CameraRoom");
		yield return null;

		var pause = GameObject.Find ("PauseMenu").GetComponent<Button> ();
		pause.onClick.Invoke ();

		var restart = GameObject.Find ("RestartLevelButton").GetComponent<Button> ();
		restart.onClick.Invoke ();

		Assert.AreEqual ("CameraRoom", SceneManager.GetActiveScene ().name);

	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator CameraRoomCanMoveToMainMenuPasses() {
		LoadSceneByName ("CameraRoom");
		yield return null;
	}
}
