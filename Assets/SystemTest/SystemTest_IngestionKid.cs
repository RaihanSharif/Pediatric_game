using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemTest_IngestionKid {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };


	[UnityTest]
	[Timeout(100000000)]
	public IEnumerator SystemTest_IngestionKidPasses() {
		LoadSceneByName ("SplashScreen");
		yield return null;
		yield return new WaitForSeconds (6.1f);
		yield return null;

		var ingestionButton = GameObject.FindGameObjectWithTag ("Ingestion").GetComponent<Button> ();
		ingestionButton.onClick.Invoke ();
		yield return new WaitForSeconds (1);

		var kidIngestionButton = GameObject.FindGameObjectWithTag ("Kid").GetComponent<Button> ();
		kidIngestionButton.onClick.Invoke ();
		yield return null;

		yield return new WaitForSeconds (10);

		var spoon = GameObject.Find ("spoon");
		for (int i = 0; i < 10; i++) {
			spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
			yield return new WaitForSeconds (0.1f);
			spoon.transform.position = new Vector3 (4.9f, 0.001f, 0f);
			yield return new WaitForSeconds (0.1f);
		}
	}
}
