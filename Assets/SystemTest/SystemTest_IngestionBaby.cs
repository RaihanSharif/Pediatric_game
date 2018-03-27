using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemTest_IngestionBaby {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}


	[UnityTest]
	[Timeout(100000000)]
	public IEnumerator SystemTest_IngestionBabyPasses() {
		LoadSceneByName ("SplashScreen");
		yield return null;
		yield return new WaitForSeconds (6.1f);
		yield return null;

		var ingestionButton = GameObject.FindGameObjectWithTag ("Ingestion").GetComponent<Button> ();
		ingestionButton.onClick.Invoke ();
		yield return new WaitForSeconds (1);

		var babyIngestionButton = GameObject.FindGameObjectWithTag ("Baby").GetComponent<Button> ();
		babyIngestionButton.onClick.Invoke ();
		yield return null;



//		Assert.AreEqual ("IngestionBaby", SceneManager.GetActiveScene ().name);

	}
}
