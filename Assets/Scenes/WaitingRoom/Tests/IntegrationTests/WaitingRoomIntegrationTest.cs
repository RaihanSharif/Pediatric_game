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

	/// <summary>
	/// Loads the waiting room scene, clicks on the trash can button,
	/// then checks whether the trash can minigame has been opened.
	/// </summary>
	[UnityTest]
	public IEnumerator WaitingRoomGoesToTrashCanReturnsTrue() {
        LoadSceneByName("WaitingRoom");
		yield return null;

		var play = GameObject.Find("TrashCanButton").GetComponent<Button>();
        play.onClick.Invoke();
        yield return null;

        Assert.AreEqual ("PaperTossScene", SceneManager.GetActiveScene().name);
	}

	/// <summary>
	/// Loads the waiting room scene, clicks on the reception button,
	/// then checks whether the reception scene has been opened.
	/// </summary>
	[UnityTest]
	public IEnumerator WaitingRoomGoesToReceptionReturnsTrue() {
		LoadSceneByName("WaitingRoom");
		yield return null;

		var play = GameObject.Find("Reception").GetComponent<Button>();
		play.onClick.Invoke();
		yield return null;

		Assert.AreEqual ("Reception", SceneManager.GetActiveScene().name);
	}

	/// <summary>
	/// Loads the waiting room scene, clicks on the tablet button, then
	/// checks whether the card matching game  can minigame has been opened.
	/// </summary>
	[UnityTest]
	public IEnumerator WaitingRoomGoesToCardMatchingGameReturnsTrue() {
		LoadSceneByName("WaitingRoom");
		yield return null;

		var gameMatching = GameObject.Find ("Button").GetComponent<Button> ();
		gameMatching.onClick.Invoke ();
		yield return null;

		Assert.AreEqual("CardMatchingGame", SceneManager.GetActiveScene().name);
	}

	/// <summary>
	/// Loads the waiting room scene, clicks on the bird button,
	/// then checks whether the flappy bird scene has been opened.
	/// </summary>
    [UnityTest]
    public IEnumerator WaitingRoomGoesToFlappyBirdReturnsTrue() {
        LoadSceneByName("WaitingRoom");
        yield return null;

        var birdObj = GameObject.Find("TheBird");
        TheBird birdScript = birdObj.GetComponent<TheBird>();

        yield return new WaitForSeconds(2);
        birdScript.OnMouseDown();
        yield return null;

        Assert.AreEqual("FlappyBird", SceneManager.GetActiveScene().name);
    }

	/// <summary>
	/// Load all three minigames and go back to waiting room each time,
	/// then check if it is possible to advance to the camera room
	/// </summary>
	[UnityTest]
	public IEnumerator WaitRoomGoesToCameraRoomReturnsTrue() {
		LoadSceneByName ("WaitingRoom");
		yield return null;

		var birdObj = GameObject.Find ("TheBird");
		TheBird birdScript = birdObj.GetComponent<TheBird> ();

		yield return new WaitForSeconds (2);
		birdScript.OnMouseDown ();
		yield return null;

		LoadSceneByName ("WaitingRoom");
		yield return null;

		var play = GameObject.Find ("TrashCanButton").GetComponent<Button> ();
		play.onClick.Invoke ();
		yield return null;

		LoadSceneByName ("WaitingRoom");
		yield return null;

		var gameMatching = GameObject.Find ("Button").GetComponent<Button> ();
		gameMatching.onClick.Invoke ();
		yield return null;

		LoadSceneByName ("WaitingRoom");
		yield return null;
	
		var progress = GameObject.Find ("RadialProgressBar").GetComponent<RadialProgressBar> ();
		var progressBarVal = progress.getCurrentBarValue ();

		// We change to camera room only if the progress down is at zero or less
		if (progressBarVal <= 0) {
			LoadSceneByName ("CameraRoom");
			yield return null;
		}

		Assert.AreEqual ("CameraRoom", SceneManager.GetActiveScene ().name);
	}
		
}
