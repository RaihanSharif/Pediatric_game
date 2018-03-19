using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InjectionIntegrationTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	/// <summary>
	/// Load creme application scene, complete it, then
	/// check whether the next scene loads successfully.
	/// </summary>
	[UnityTest]
	public IEnumerator InjectionGoesFromCremeToInjectionPasses() {
		LoadSceneByName ("CremeApplication");
		yield return null;

		var fader = new GameObject ().AddComponent<Fading> ();
		fader.moveToNextScene ();
		yield return null;

		Assert.AreEqual ("InjectionBaby", SceneManager.GetActiveScene().name);

	}

	/// <summary>
	/// Load injection scene, complete it, then
	/// check whether the final scene loads succesffuly.
	/// </summary>
	[UnityTest]
	public IEnumerator InjectionGoesFromInjectionToFinalPasses() {
		LoadSceneByName ("CremeApplication");
		yield return null;

		var fader = new GameObject ().AddComponent<Fading> ();
		fader.moveToNextScene ();
		yield return null;

		fader.moveToNextScene ();
		yield return null;

		Assert.AreEqual ("BabyInjectionGameCompleted", SceneManager.GetActiveScene().name);

	}
}
