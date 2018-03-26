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

		var cremeSpot = GameObject.Find ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		cremeSpot.GetComponent<Animator> ().Play("CremeSpot1ChangeColor");
		yield return new WaitForSeconds (5);

		var otherCremeSpot = GameObject.Find ("CremeSpot2").GetComponent<CremeSpotCollision> ();
		otherCremeSpot.GetComponent<Animator> ().Play("CremeSpot2ChangeColor");
		yield return new WaitForSeconds (5);

		var fader = GameObject.Find ("fadeImage").GetComponent<Fading> ();
		yield return null;
		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();

		if (arm.getCompleted()) {
			fader.moveToNextScene ();
			yield return null;
			yield return new WaitForSeconds (5);
		}

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

		var circle = GameObject.Find ("Button").GetComponent<Button> ();
		circle.onClick.Invoke ();
		yield return null;

		var cremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		var smiley = GameObject.Find ("Smiley1").GetComponent<Smiley> ();
		cremeSpot.injectionIsDone (smiley);
		yield return new WaitForSeconds (5);

		var otherCremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot2").GetComponent<CremeSpotCollision> ();
		var otherSmiley = GameObject.Find ("Smiley2").GetComponent<Smiley> ();
		otherCremeSpot.injectionIsDone (otherSmiley);
		yield return new WaitForSeconds (5);

		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		yield return new WaitForSeconds (3);

		if (arm.getCompleted()) {
			LoadSceneByName ("WaitingRoom");
			yield return null;
		}

		Assert.AreEqual ("WaitingRoom", SceneManager.GetActiveScene().name);

	}
}
