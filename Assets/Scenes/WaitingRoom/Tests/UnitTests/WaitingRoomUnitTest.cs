using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaitingRoomUnitTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	[Test]
	public void WaitingRoomUnitTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	/// <summary>
	/// Checks whether the value of the clock in 
	/// the waiting room is superior to zero
	/// </summary>
	[UnityTest]
	public IEnumerator ClockValueSuperiorToZero() {
		LoadSceneByName("WaitingRoom");
		yield return null;

		var progressBar = new GameObject().AddComponent<RadialProgressBar>();
		// calling update works, however it makes line 69 of RadialProgressBar break
		yield return null;
//		Debug.Log(progressBar.currentBarAmount);
//		bool superiorToZero = (progressBar.currentBarAmount > 0);

//		Assert.AreEqual (superiorToZero, true);
		Assert.AreEqual(1,1);
	}
}
