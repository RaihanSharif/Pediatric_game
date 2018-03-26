using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class CameraRoomIntegrationTest {

	[UnityTest]
	public IEnumerator CameraRoomCanRestartLevelPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator CameraRoomCanMoveToMainMenuPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
