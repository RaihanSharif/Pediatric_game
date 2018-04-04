using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemTest_Injection {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };

	/// <summary>
	/// Go through the whole game selecting the Injection option
	/// </summary>
	[UnityTest]
	[Timeout(100000000)]
	public IEnumerator SystemTest_InjectionPasses() {
		// Load Splash Screen
		LoadSceneByName ("SplashScreen");
		yield return null;
		yield return new WaitForSeconds (6.1f);
		yield return null;

		// After 6 seconds, the main menu should have been reached, select Injection
		var injectionButton = GameObject.FindGameObjectWithTag ("Injection").GetComponent<Button> ();
		injectionButton.onClick.Invoke ();
		yield return null;

		// Pour creme on two arm spots and move to Injection
		#region CremeApplication
		var cremeSpot = GameObject.Find ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		cremeSpot.GetComponent<Animator> ().Play("CremeSpot1ChangeColor");
		yield return new WaitForSeconds (5);

		var otherCremeSpot = GameObject.Find ("CremeSpot2").GetComponent<CremeSpotCollision> ();
		otherCremeSpot.GetComponent<Animator> ().Play("CremeSpot2ChangeColor");
		yield return new WaitForSeconds (5);

		var fader = GameObject.Find ("fadeImage").GetComponent<Fading> ();
		yield return null;
		var arm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();

		if (arm.getCompleted()) {
			fader.moveToNextScene ();
			yield return null;
			yield return new WaitForSeconds (1);
		}
		#endregion

		// Inject both creme spots and move to waiting room
		#region Injection
		var circle = GameObject.Find ("Button").GetComponent<Button> ();
		circle.onClick.Invoke ();
		yield return null;

		var aCremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot1").GetComponent<CremeSpotCollision> ();
		var smiley = GameObject.Find ("Smiley1").GetComponent<Smiley> ();
		aCremeSpot.injectionIsDone (smiley);
		yield return new WaitForSeconds (5);

		var anotherCremeSpot = GameObject.FindGameObjectWithTag ("CremeSpot2").GetComponent<CremeSpotCollision> ();
		var otherSmiley = GameObject.Find ("Smiley2").GetComponent<Smiley> ();
		anotherCremeSpot.injectionIsDone (otherSmiley);
		yield return new WaitForSeconds (5);

		var someArm = GameObject.FindGameObjectWithTag ("Arm").GetComponent<Arm> ();
		yield return new WaitForSeconds (3);

		if (someArm.getCompleted()) {
			LoadSceneByName ("WaitingRoom");
			yield return null;
			yield return new WaitForSeconds (2);
		}
		#endregion

		// Load all three minigames and go back to waiting room

		// Flappy bird 
		#region Flappybird
		var birdObj = GameObject.Find("TheBird");
		var birdScript = birdObj.GetComponent<TheBird>();
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
		#region Papertoss
		var trashCan = GameObject.Find("TrashCanButton").GetComponent<Button>();
		trashCan.onClick.Invoke();
		yield return null;
		yield return new WaitForSeconds (3);

		var nextButton = GameObject.Find ("BackButton").GetComponent<Button> ();
		nextButton.onClick.Invoke ();
		yield return null;
		#endregion

		// Matching cards
		#region Matchingcards
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
		#region CameraRoom
		yield return new WaitForSeconds (10);

		var sandbag1 = GameObject.FindGameObjectWithTag(tags[2]);
		GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[2]));
		sandbag1.transform.position = new Vector2(-2f, -2f);
		yield return null;
		yield return new WaitForSeconds(1);
		var testingScript = GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>();
		testingScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var sandbag2 = GameObject.FindGameObjectWithTag(tags[3]);
		GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[3]));
		sandbag2.transform.position = new Vector2(-2f, 1.65f);
		yield return null;
		yield return new WaitForSeconds(1);
		var testScript = GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>();
		testScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var strap1 = GameObject.FindGameObjectWithTag(tags[0]);
		GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[0]));
		strap1.transform.position = new Vector2(-4, 0.2f);
		yield return null;
		yield return new WaitForSeconds(1);
		var theScript = GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>();
		theScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var strap2 = GameObject.FindGameObjectWithTag(tags[1]);
		GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[1]));
		strap2.transform.position = new Vector2(0f, 0.2f);
		yield return null;
		yield return new WaitForSeconds(1);
		var aScript = GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>();
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
		GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[6]));
		cameraBottom.transform.position = new Vector2(6.3f, 0f);
		yield return null;
		yield return new WaitForSeconds(1);
		var anotherScript = GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>();
		anotherScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		var table = GameObject.FindGameObjectWithTag(tags[4]);
		GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[4]));
		table.transform.position = new Vector2(1.75f, 0f);
		yield return null;
		yield return new WaitForSeconds(1);
		var lastScript = GameObject.FindGameObjectWithTag(tags[5]).GetComponent<DragAndDropCameraRoom>();
		lastScript.clickIntoPlace();
		yield return new WaitForSeconds(1);

		cameraTop.GetComponent<DragAndDropCameraRoom>().setDraggedObject(GameObject.FindGameObjectWithTag(tags[5]));
		cameraTop.transform.position = new Vector2(2.3f, 0f);
		yield return null;
		yield return new WaitForSeconds(5);


		if (lastScript.getlevelOver()) {
			LoadSceneByName ("MainMenu");
			yield return null;
		}
		#endregion

		yield return new WaitForSeconds (2);

		Assert.AreEqual ("MainMenu", SceneManager.GetActiveScene ().name);

	}
}
