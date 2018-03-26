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

		var play = GameObject.Find("trashCanButton").GetComponent<Button>();
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

    [UnityTest]
    public IEnumerator WaitingRoomGoesToFlappyBirdReturnsTrue()
    {
        LoadSceneByName("WaitingRoom");
        yield return null;

        var birdObj = GameObject.Find("TheBird");
        TheBird birdScript = birdObj.GetComponent<TheBird>();

        yield return new WaitForSeconds(2);
        birdScript.OnMouseDown();
        yield return null;

        Assert.AreEqual("FlappyBird", SceneManager.GetActiveScene().name);
    }
}
