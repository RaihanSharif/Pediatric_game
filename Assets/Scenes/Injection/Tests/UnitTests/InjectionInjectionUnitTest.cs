using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InjectionInjectionUnitTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	/// <summary>
	/// Injects first arm spot and checks whether it has correctly
	/// incremented the value of CreamCurrentProgress inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedOncePasses() {
		LoadSceneByName ("InjectionBaby");
		yield return null;
		var circle = GameObject.Find ("Button").GetComponent<Button> ();
		circle.onClick.Invoke ();
		yield return null;

		var cremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		var smiley = GameObject.Find ("Smiley1").GetComponent<Smiley>();
		cremeSpot.injectionIsDone (smiley);
		yield return new WaitForSeconds (5);

		var arm = GameObject.FindGameObjectWithTag("Arm").GetComponent<Arm>();

		Assert.AreEqual (arm.ProgressOffset, arm.CreamCurrentProgress);

	}

	/// <summary>
	/// Injects first arm spot and checks whether it has changed the
	/// value of the variable complete to true inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedOnceCompleteIsTrueFails() {
		LoadSceneByName ("InjectionBaby");
		yield return null;
		var circle = GameObject.Find ("Button").GetComponent<Button> ();
		circle.onClick.Invoke ();
		yield return null;
	
		var cremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		var smiley = GameObject.Find ("Smiley1").GetComponent<Smiley> ();
		cremeSpot.injectionIsDone (smiley);
		yield return new WaitForSeconds (5);

		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();

		Assert.AreNotEqual (true, arm.getCompleted());

	}

	/// <summary>
	/// Injects first and second arm spot and checks whether it has correctly
	/// incremented the value of CreamCurrentProgress inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedTwicePasses() {
		LoadSceneByName ("InjectionBaby");
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

		Assert.AreEqual (arm.CreamMaxProgress, arm.CreamCurrentProgress);
	}

	/// <summary>
	/// Injects first and second arm spot and checks whether it has changed
	/// the value of the variable complete to true inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedTwiceCompletedIsTruePasses() {
		LoadSceneByName ("InjectionBaby");
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

		Assert.AreEqual (true, arm.getCompleted());
	}

	/// <summary>
	/// Injects only the first arm spot and checks whether it is possible
	/// to change scenes once this has been done (it shouldn't be)
	/// </summary>
	[UnityTest]
	public IEnumerator CremeNotCompletedCanMoveToNextSceneFails() {
		LoadSceneByName ("InjectionBaby");
		yield return null;
		var circle = GameObject.Find ("Button").GetComponent<Button> ();
		circle.onClick.Invoke ();
		yield return null;

		var cremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		var smiley = GameObject.Find ("Smiley1").GetComponent<Smiley> ();
		cremeSpot.injectionIsDone (smiley);
		yield return new WaitForSeconds (5);

		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();

		var fader = GameObject.Find ("fadeImage").GetComponent<Fading> ();
		yield return new WaitForSeconds (3);

		if (arm.getCompleted()) {
			fader.moveToNextScene ();
			yield return null;
		}

		Assert.AreNotEqual ("BabyInjectionGameCompleted", SceneManager.GetActiveScene().name);

	}



	/// <summary>
	/// Injects first and second arm spot and checks whether it is 
	/// possible to change scenes once this has been done
	/// </summary>
	[UnityTest]
	public IEnumerator CremeCompletedCanMoveToNextScenePasses() {
		LoadSceneByName ("InjectionBaby");
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
		var fader = GameObject.Find ("fadeImage").GetComponent<Fading> ();
		yield return new WaitForSeconds (3);

		if (arm.getCompleted()) {
			fader.moveToNextScene ();
			yield return null;
		}

		Assert.AreEqual ("BabyInjectionGameCompleted", SceneManager.GetActiveScene().name);

	}


}
