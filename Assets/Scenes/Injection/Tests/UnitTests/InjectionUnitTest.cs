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
	/// Calls IncreaseProgress method once and checks whether it
	/// has correctly incremented the value to CreamCurrentProgress
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedOncePasses() {
		var arm = new GameObject ().AddComponent<Arm> ();
		yield return null;
		arm.IncreaseProgress(arm.ProgressOffset);

		Assert.AreEqual (arm.ProgressOffset, arm.CreamCurrentProgress);

	}

	/// <summary>
	/// Calls IncreaseProgress method once and checks whether it
	/// has changed the value of the variable complete to true
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedOnceCompleteIsTrueFails() {
		var arm = new GameObject ().AddComponent<Arm> ();
		yield return null;
		arm.IncreaseProgress(arm.ProgressOffset);

		Assert.AreNotEqual (true, arm.getCompleted());

	}

	/// <summary>
	/// Calls start method twice and checks whether it
	/// has correctly incremented the value to the max. 
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedTwicePasses() {
		var arm = new GameObject ().AddComponent<Arm> ();
		yield return null;
		arm.startProcess ();
		arm.startProcess ();
		Assert.AreEqual (arm.CreamMaxProgress, arm.CreamCurrentProgress);
	}

	/// <summary>
	/// Calls start method twice and checks whether the
	/// variable completed has been changed to true. 
	/// </summary>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedTwiceCompletedIsTruePasses() {
		var arm = new GameObject ().AddComponent<Arm> ();
		yield return null;
		arm.startProcess ();
		arm.startProcess ();
		Assert.AreEqual (true, arm.getCompleted());
	}
}
