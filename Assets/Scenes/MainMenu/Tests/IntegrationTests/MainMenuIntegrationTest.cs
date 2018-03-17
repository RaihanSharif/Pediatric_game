using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuIntegrationTest {

	/// <summary>
	/// Checking clicking on two buttons : 
	/// 0 to 5 years then Ingestion, leads
	/// to the loading of the Baby Injection Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToIngestionBabyPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.babyButtonPressed ();
		manager.ingestionButtonPressed ();
		Assert.AreEqual(EventManager.chosenScene, "IngestionBaby");
		yield return null;
	}

	/// <summary>
	/// Checking clicking on two buttons : 
	/// Ingestion then 0 to 5 years, leads
	/// to the loading of the Baby Injection Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToInggestionBabyPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.ingestionButtonPressed ();
		manager.babyButtonPressed ();
		Assert.AreEqual(EventManager.chosenScene, "IngestionBaby");
		yield return null;
	}

	/// <summary>
	/// Checking clicking on two buttons : 
	/// 6 to 10 years then Ingestion, leads
	/// to the loading of the Kid Ingestion Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToIngestionKidPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.kidButtonPressed ();
		manager.ingestionButtonPressed ();
		Assert.AreEqual(EventManager.chosenScene, "IngestionKid");
		yield return null;
	}

	/// <summary>
	/// Checking clicking on two buttons : 
	/// Ingestion then 6 to 10 years, leads
	/// to the loading of the Kid Ingestion Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToInggestionKidPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.ingestionButtonPressed ();
		manager.kidButtonPressed ();
		Assert.AreEqual(EventManager.chosenScene, "IngestionKid");
		yield return null;
	}

	/// <summary>
	/// Checking clicking on two buttons : 
	/// 6 to 10 years then Injection, leads
	/// to the loading of the Kid Injection Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToInjectionBabyPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.babyButtonPressed ();
		manager.injectionButtonPressed ();
		Assert.AreEqual(EventManager.chosenScene, "CremeApplication");
		yield return null;
	}

	/// <summary>
	/// Checking clicking on two buttons : 
	/// Injection then 6 to 10 years, leads
	/// to the loading of the Kid Injection Scene 
	/// </summary>
	/// <returns>The menu moves to ingestion baby passed.</returns>
	[UnityTest]
	public IEnumerator MainMenuMovesToInjjectionBabyPassed() {
		var manager = new GameObject().AddComponent<EventManager>();
		manager.injectionButtonPressed ();
		manager.babyButtonPressed ();
		Assert.AreEqual(EventManager.chosenScene, "CremeApplication");
		yield return null;
	}

}
