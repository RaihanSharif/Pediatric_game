using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngKidIntegrationTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	/// <summary>
	/// Integration test that checks whether we can script the 
	/// completion of the scene and move along to the next one 
	/// </summary>
	[UnityTest]
	public IEnumerator KidEatsAllAndMovesToWaitingRoomPasses() {
		var next = "WaitingRoom";
		LoadSceneByName ("IngestionKid");
		yield return null;

		var spoon = GameObject.Find ("spoon");
		for (int i = 0; i < 24; i++) {
			spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
			yield return new WaitForSeconds (0.1f);
			spoon.transform.position = new Vector3 (4.9f, 0.001f, 0f);
			yield return new WaitForSeconds (0.1f);
		}
		spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
		yield return null;

		var script = new GameObject ().AddComponent<LevelFinishedMenu> ();
		script.LoadNextScene (next);
		yield return null;

		Assert.AreEqual ("WaitingRoom", SceneManager.GetActiveScene().name);
	}

	/// <summary>
	/// Integration test that checks whether we can script the 
	/// completion of the scene and move along to the main menu
	/// </summary>
	/// <returns>The eats all and moves to main menu passes.</returns>
	[UnityTest]
	public IEnumerator KidEatsAllAndMovesToMainMenuPasses() {
		LoadSceneByName ("IngestionKid");
		yield return null;

		var spoon = GameObject.Find ("spoon");
		for (int i = 0; i < 24; i++) {
			spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
			yield return new WaitForSeconds (0.1f);
			spoon.transform.position = new Vector3 (4.9f, 0.001f, 0f);
			yield return new WaitForSeconds (0.1f);
		}
		spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
		yield return null;

		var script = new GameObject ().AddComponent<LevelFinishedMenu> ();
		script.Restart ();
		yield return null;

		Assert.AreEqual ("MainMenu", SceneManager.GetActiveScene().name);
	}

}
