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

		Assert.AreEqual (SceneManager.GetActiveScene ().name, "MainMenu");



	}
}
