using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaitingRoomIntegrationTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	[Test]
	public void WaitingRoomIntegrationTestSimplePasses() {
		// Use the Assert class to test conditions.
	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator WaitingRoomIntegrationTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        LoadSceneByName("WaitingRoom");
		yield return null;

        var play = GameObject.FindGameObjectWithTag("Trash").GetComponent<Button>();
        play.onClick.Invoke();
        yield return null;

        Assert.AreEqual ("PaperTossScene", SceneManager.GetActiveScene().name);
	}
}
