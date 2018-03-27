using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemTest_Injection {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };

	[UnityTest]
	[Timeout(100000000)]
	public IEnumerator SystemTest_InjectionPasses() {
		// Load Splash Screen
		LoadSceneByName ("SplashScreen");
		yield return null;
		yield return new WaitForSeconds (6.1f);
		yield return null;

		// After 6 seconds, the main menu should have been reached, select Injection
		var injectionButton = GameObject.FindGameObjectWithTag ("Injection").GetComponent<Button> ();
		injectionButton.onClick.Invoke ();
		yield return null;

		// Pour creme on two arm spots and move to Injection
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
			yield return new WaitForSeconds (1);
		}

		// Injection both creme spots and move to waiting room
		var circle = GameObject.Find ("Button").GetComponent<Button> ();
		circle.onClick.Invoke ();
		yield return null;

		var aCremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		var smiley = GameObject.Find ("Smiley1").GetComponent<Smiley> ();
		aCremeSpot.injectionIsDone (smiley);
		yield return new WaitForSeconds (5);

		var anotherCremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot2").GetComponent<CremeSpotCollision> ();
		var otherSmiley = GameObject.Find ("Smiley2").GetComponent<Smiley> ();
		anotherCremeSpot.injectionIsDone (otherSmiley);
		yield return new WaitForSeconds (5);

		var someArm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		yield return new WaitForSeconds (3);

		if (someArm.getCompleted()) {
			LoadSceneByName ("WaitingRoom");
			yield return null;
		}

		Assert.AreEqual ("WaitingRoom", SceneManager.GetActiveScene ().name);

	}
}
