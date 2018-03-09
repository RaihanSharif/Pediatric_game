﻿using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuIntegrationTest {

	[Test]
	public void MainMenuIntegrationTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator MainMenuIntegrationTestWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		var manager = new GameObject().AddComponent<EventManager>();
		manager.babyButtonPressed ();
		manager.ingestionButtonPressed ();
		Assert.AreEqual(manager.chosenScene, "IngestionBaby");
		yield return null;
	}
}
