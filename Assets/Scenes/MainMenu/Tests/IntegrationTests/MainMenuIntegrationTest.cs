using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuIntegrationTest {

	/// <summary>
	/// Checking clicking on two buttons : 
	/// 0 to 5 years & Ingestion, leads
	/// to the loading of the Baby Injection Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToIngestionBabyPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.babyButtonPressed ();
		manager.ingestionButtonPressed ();
		Assert.AreEqual(manager.chosenScene, "IngestionBaby");
		yield return null;
	}

	/// <summary>
	/// Checking clicking on two buttons : 
	/// 0 to 5 years & Ingestion, leads
	/// to the loading of the Baby Injection Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToIngestionKidPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.kidButtonPressed ();
		manager.ingestionButtonPressed ();
		Assert.AreEqual(manager.chosenScene, "IngestionKid");
		yield return null;
	}

	/// <summary>
	/// Checking clicking on two buttons : 
	/// 6 to 10 years & Injection, leads
	/// to the loading of the Baby Injection Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToInjectionBabyPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.babyButtonPressed ();
		manager.injectionButtonPressed ();
		Assert.AreEqual(manager.chosenScene, "InjectionKid");
		yield return null;
	}

}
