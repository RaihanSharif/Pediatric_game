using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SystemTest_IngestionKid {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };


	[UnityTest]
	[Timeout(100000000)]
	public IEnumerator SystemTest_IngestionKidPasses() {
		// Load Splash Screen
		LoadSceneByName ("SplashScreen");
		yield return null;
		yield return new WaitForSeconds (6.1f);
		yield return null;

		// After 6 seconds, the main menu should have been reached, select Ingestion and Food
		var ingestionButton = GameObject.FindGameObjectWithTag ("Ingestion").GetComponent<Button> ();
		ingestionButton.onClick.Invoke ();
		yield return new WaitForSeconds (1);

		var kidIngestionButton = GameObject.FindGameObjectWithTag ("Kid").GetComponent<Button> ();
		kidIngestionButton.onClick.Invoke ();
		yield return null;

		// Make kid eat all the food and move along to waiting room
		yield return new WaitForSeconds (10);
		var spoon = GameObject.Find ("spoon");
		for (int i = 0; i < 10; i++) {
			spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
			yield return new WaitForSeconds (0.1f);
			spoon.transform.position = new Vector3 (4.9f, 0.001f, 0f);
			yield return new WaitForSeconds (0.1f);
		}

		spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
		yield return null;

		LoadSceneByName ("WaitingRoom");
		yield return null;
		yield return new WaitForSeconds (2);

		// Load all three minigames and go back to waiting room

		// Flappy bird 
		#region 
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

		LoadSceneByName ("CameraRoom");
		yield return null;

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
