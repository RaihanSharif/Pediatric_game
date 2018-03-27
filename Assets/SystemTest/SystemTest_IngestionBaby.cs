using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemTest_IngestionBaby {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };


	[UnityTest]
	[Timeout(100000000)]
	public IEnumerator SystemTest_IngestionBabyPasses() {

		// Load Splash Screen
		LoadSceneByName ("SplashScreen");
		yield return null;
		yield return new WaitForSeconds (6.1f);
		yield return null;

		// After 6 seconds, the main menu should have been reached, select Ingestion and Milk
		var ingestionButton = GameObject.FindGameObjectWithTag ("Ingestion").GetComponent<Button> ();
		ingestionButton.onClick.Invoke ();
		yield return new WaitForSeconds (1);

		var babyIngestionButton = GameObject.FindGameObjectWithTag ("Baby").GetComponent<Button> ();
		babyIngestionButton.onClick.Invoke ();
		yield return null;

		// Pop all the bubbles and finish the milk, then move to waiting room
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

		// Load all three minigames and go back to waiting room

		// Flappy bird 
		#region 
		var birdObj = GameObject.Find("TheBird");
		TheBird birdScript = birdObj.GetComponent<TheBird>();
		yield return new WaitForSeconds(2);
		birdScript.OnMouseDown();
		yield return null;

		var gameControlObject = GameObject.Find("GameControl");
		gameControlObject.GetComponent<GameControl> ().setTimeTo1 ();
		var birdObject = GameObject.Find("Bird");
		birdObject.transform.position = new Vector3 (1f, -2f, 0f);
		yield return new WaitForSeconds (2);

		LoadSceneByName ("WaitingRoom");
		yield return null;
		yield return new WaitForSeconds (2);
		#endregion

		// Paper toss
		#region
		var trashCan = GameObject.Find("TrashCanButton").GetComponent<Button>();
		trashCan.onClick.Invoke();
		yield return null;
		yield return new WaitForSeconds (3);

		var nextButton = GameObject.Find ("BackButton").GetComponent<Button> ();
		nextButton.onClick.Invoke ();
		yield return null;
		#endregion

		// Matching cards
		#region
		var gameMatching = GameObject.Find("Button").GetComponent<Button>();
		gameMatching.onClick.Invoke ();
		yield return null;
		yield return new WaitForSeconds(2);

		var theNextButton = GameObject.Find("BackButton").GetComponent<Button>();
		theNextButton.onClick.Invoke();
		yield return null;
		#endregion

		var progress = GameObject.Find ("RadialProgressBar").GetComponent<RadialProgressBar> ();
		var progressBarVal = progress.getCurrentBarValue ();

		// We change to camera room only if the progress down is at zero or less
		if (progressBarVal <= 0) {
			LoadSceneByName ("CameraRoom");
			yield return null;
		}

		// Camera Room
		#region 
		yield return new WaitForSeconds (10);

		var sandbag1 = GameObject.FindGameObjectWithTag(tags[2]);
		sandbag1.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[2]));
		sandbag1.transform.position = new Vector2(-2f, -2f);
		yield return null;
		yield return new WaitForSeconds(1);
		var testingScript = sandbag1.GetComponent<DragAndDropCameraRoom>();
		testingScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var sandbag2 = GameObject.FindGameObjectWithTag(tags[3]);
		sandbag2.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[3]));
		sandbag2.transform.position = new Vector2(-2f, 1.65f);
		yield return null;
		yield return new WaitForSeconds(1);
		var testScript = sandbag2.GetComponent<DragAndDropCameraRoom>();
		testScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var strap1 = GameObject.FindGameObjectWithTag(tags[0]);
		strap1.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[0]));
		strap1.transform.position = new Vector2(-4, 0.2f);
		yield return null;
		yield return new WaitForSeconds(1);
		var theScript = strap1.GetComponent<DragAndDropCameraRoom>();
		theScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var strap2 = GameObject.FindGameObjectWithTag(tags[1]);
		strap2.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[1]));
		strap2.transform.position = new Vector2(0f, 0.2f);
		yield return null;
		yield return new WaitForSeconds(1);
		var aScript = strap1.GetComponent<DragAndDropCameraRoom>();
		aScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var cameraTop = GameObject.FindGameObjectWithTag(tags[5]);
		cameraTop.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[5]));
		cameraTop.transform.position = new Vector2(6.3f, 0f);
		yield return null;
		yield return new WaitForSeconds(1);
		var someScript = cameraTop.GetComponent<DragAndDropCameraRoom>();
		someScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var cameraBottom = GameObject.FindGameObjectWithTag(tags[6]);
		cameraBottom.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[6]));
		cameraBottom.transform.position = new Vector2(6.3f, 0f);
		yield return null;
		yield return new WaitForSeconds(1);
		var anotherScript = cameraBottom.GetComponent<DragAndDropCameraRoom>();
		anotherScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var table = GameObject.FindGameObjectWithTag(tags[4]);
		table.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[4]));
		table.transform.position = new Vector2(1.75f, 0f);
		yield return null;
		yield return new WaitForSeconds(1);
		var lastScript = table.GetComponent<DragAndDropCameraRoom>();
		lastScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		if (table.GetComponent<DragAndDropCameraRoom> ().gettableInPLace ()) {
			LoadSceneByName ("MainMenu");
			yield return null;
		}
		#endregion

		yield return new WaitForSeconds (2);

		Assert.AreEqual ("MainMenu", SceneManager.GetActiveScene ().name);

	}
}
