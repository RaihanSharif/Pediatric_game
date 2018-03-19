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
		yield return null;
	}

	/// <summary>
	/// Calls IncreaseProgress method twice and checks whether it
	/// has correctly incremented the value to the max. 
	/// </summary>
	/// <returns>The progress incremented twice passes.</returns>
	[UnityTest]
	public IEnumerator ArmProgressIncrementedTwicePasses() {
		yield return null;
	}
}
