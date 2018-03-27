using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngBabyIntegrationTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
		
	/// <summary>
	/// Baby drinks all the menu and moves to main menu
	/// </summary>
	[UnityTest]
	public IEnumerator BabyDrinksAllAndMovesToMainMenuPasses() {
		LoadSceneByName ("IngestionBaby");
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (0.1f);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var secondPurple = GameObject.Find ("PinkBubble2").GetComponent<BubbleClick> ();
		secondPurple.OnMouseDown ();
		secondPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdPurple = GameObject.Find ("PinkBubble3").GetComponent<BubbleClick> ();
		thirdPurple.OnMouseDown ();
		thirdPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var bottle = GameObject.Find ("babyBottle").GetComponent<playAnimationOnClick> ();
		bottle.OnMouseDown ();
		var anim = GameObject.Find ("babyBottle").GetComponent<Animator> ();
		anim.Play ("BabyBottleAnim");
		var bottleScript = GameObject.Find ("babyBottle").GetComponent<Babybottle> ();
		bottleScript.OnMouseDown ();
		yield return null;
		yield return new WaitForSeconds (0.4f);

		for (int i = 0; i < 5; i++) {
			bottle.OnMouseDown ();
			anim.Play ("BabyBottleAnim");
			bottleScript.OnMouseDown ();
			yield return null;
			yield return new WaitForSeconds (0.4f);
		}

		if (bottleScript.gameWon) {
			LoadSceneByName ("MainMenu");
			yield return null;
		}

		Assert.AreEqual ("MainMenu", SceneManager.GetActiveScene().name);

	}

	/// <summary>
	/// Baby drinks all the milk and moves on to the next scene
	/// </summary>
	[UnityTest]
	public IEnumerator BabyDrinksAllAndMovesToWaitingRoomPasses() {
		LoadSceneByName ("IngestionBaby");
		yield return null;

		yield return new WaitForSeconds (3);
		var bubble = GameObject.Find ("BlueBubble1").GetComponent<BubbleClick> ();
		bubble.OnMouseDown ();
		yield return new WaitForSeconds (2);
		var otherBubble = GameObject.Find ("PinkBubble1").GetComponent<BubbleClick> ();
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (0.1f);
		otherBubble.OnMouseDown ();
		yield return new WaitForSeconds (1);

		var secondBlue = GameObject.Find ("BlueBubble2").GetComponent<BubbleClick> ();
		secondBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdBlue = GameObject.Find ("BlueBubble3").GetComponent<BubbleClick> ();
		thirdBlue.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var secondPurple = GameObject.Find ("PinkBubble2").GetComponent<BubbleClick> ();
		secondPurple.OnMouseDown ();
		secondPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var thirdPurple = GameObject.Find ("PinkBubble3").GetComponent<BubbleClick> ();
		thirdPurple.OnMouseDown ();
		thirdPurple.OnMouseDown ();
		yield return new WaitForSeconds (2);

		var bottle = GameObject.Find ("babyBottle").GetComponent<playAnimationOnClick> ();
		bottle.OnMouseDown ();
		var anim = GameObject.Find ("babyBottle").GetComponent<Animator> ();
		anim.Play ("BabyBottleAnim");
		var bottleScript = GameObject.Find ("babyBottle").GetComponent<Babybottle> ();
		bottleScript.OnMouseDown ();
		yield return null;
		yield return new WaitForSeconds (0.4f);

		for (int i = 0; i < 5; i++) {
			bottle.OnMouseDown ();
			anim.Play ("BabyBottleAnim");
			bottleScript.OnMouseDown ();
			yield return null;
			yield return new WaitForSeconds (0.4f);
		}

		if (bottleScript.gameWon) {
			LoadSceneByName ("WaitingRoom");
			yield return null;
		}

		Assert.AreEqual ("WaitingRoom", SceneManager.GetActiveScene().name);

	}
}
