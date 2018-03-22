using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InjectionUnitTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	/// <summary>
	/// Fills up first creme spot and checks whether it has correctly
	/// incremented the value of CreamCurrentProgress inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedOncePasses() {
		LoadSceneByName ("CremeApplication");
		yield return null;
		var arm = GameObject.FindGameObjectWithTag("Arm").GetComponent<Arm>();
		arm.IncreaseProgress(arm.ProgressOffset);

		Assert.AreEqual (arm.ProgressOffset, arm.CreamCurrentProgress);

	}

	/// <summary>
	/// Fills up first creme spot and checks whether it has changed the
	/// value of the variable complete to true inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedOnceCompleteIsTrueFails() {
		LoadSceneByName ("CremeApplication");
		yield return null;
		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		arm.IncreaseProgress(arm.ProgressOffset);

		Assert.AreNotEqual (true, arm.getCompleted());

	}

	/// <summary>
	/// Fills up first and second creme spot and checks whether it has correctly
	/// incremented the value of CreamCurrentProgress inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedTwicePasses() {
		LoadSceneByName ("CremeApplication");
		yield return null;
		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		arm.startProcess ();
		arm.startProcess ();

		Assert.AreEqual (arm.CreamMaxProgress, arm.CreamCurrentProgress);
	}

	/// <summary>
	/// Fills up first and second creme spot and checks whether it has changed
	/// the value of the variable complete to true inside the Arm script
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedTwiceCompletedIsTruePasses() {
		LoadSceneByName ("CremeApplication");
		yield return null;
		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		arm.startProcess ();
		arm.startProcess ();

		Assert.AreEqual (true, arm.getCompleted());
	}

	/// <summary>
	/// Fills up only the first creme spot and checks whether it is possible
	/// to change scenes once this has been done (it shouldn't be)
	/// </summary>
	[UnityTest]
	public IEnumerator CremeNotCompletedCanMoveToNextSceneFails() {
		LoadSceneByName ("CremeApplication");
		yield return null;
		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		arm.startProcess ();
		var fader = GameObject.Find ("fadeImage").GetComponent<Fading> ();
		yield return new WaitForSeconds (3);

		if (arm.getCompleted()) {
			fader.moveToNextScene ();
			yield return null;
		}

		Assert.AreNotEqual ("InjectionBaby", SceneManager.GetActiveScene().name);

	}



	/// <summary>
	/// Fills up first and second creme spot and checks whether it is 
	/// possible to change scenes once this has been done
	/// </summary>
	[UnityTest]
	public IEnumerator CremeCompletedCanMoveToNextScenePasses() {
		LoadSceneByName ("CremeApplication");
		yield return null;
		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		arm.startProcess ();
		arm.startProcess ();
		var fader = GameObject.Find ("fadeImage").GetComponent<Fading> ();
		yield return new WaitForSeconds (3);

		if (arm.getCompleted()) {
			fader.moveToNextScene ();
			yield return null;
		}

		Assert.AreEqual ("InjectionBaby", SceneManager.GetActiveScene().name);

	}





}
