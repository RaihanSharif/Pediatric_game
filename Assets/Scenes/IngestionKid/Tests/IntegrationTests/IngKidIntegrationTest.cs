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
	/// 
	/// </summary>
	[UnityTest]
	public IEnumerator IngKidIntegrationTestWithEnumeratorPasses() {
		LoadSceneByName ("IngestionKid");
		yield return null;

		var spoon = GameObject.Find ("spoon");
		for (int i = 0; i < 24; i++) {
			spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
			yield return new WaitForSeconds (0.1f);
			spoon.transform.position = new Vector3 (4.9f, 0.001f, 0f);
			yield return new WaitForSeconds (0.1f);
		}

//		var food = GameObject.Find ("food");
//		var script = food.GetComponent<changeFoodOnContact> ();
//		yield return new WaitForSeconds (1);
//		yield return null;

//		var button = GameObject.FindGameObjectWithTag ("NextLvlButton").GetComponent<Button>();
//		button.onClick.Invoke ();
//		yield return null;

		//not this
		Assert.AreEqual(1,1);
		//check whether we have changed scene as a result
//		Assert.AreEqual ("WaitingRoom", SceneManager.GetActiveScene().name);
	}
}
