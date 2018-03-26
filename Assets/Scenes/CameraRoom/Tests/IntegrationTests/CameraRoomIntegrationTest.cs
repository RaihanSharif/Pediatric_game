using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraRoomIntegrationTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	private string[] tags = { "Strap1", "Strap2", "Sandbag1", "Sandbag2", "Table", "CameraTop", "CameraBottom" };

	[UnityTest]
	public IEnumerator CameraRoomCanRestartLevelPasses() {
		LoadSceneByName ("CameraRoom");
		yield return null;

		var pause = GameObject.FindGameObjectWithTag ("Pause").GetComponent<Button> ();
		pause.onClick.Invoke ();

		var restart = GameObject.Find ("RestartLevelButton").GetComponent<Button> ();
		restart.onClick.Invoke ();

		Assert.AreEqual ("CameraRoom", SceneManager.GetActiveScene ().name);

	}

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator CameraRoomCanMoveToMainMenuPasses() {
		LoadSceneByName ("CameraRoom");
		yield return null;
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

		Assert.AreEqual ("MainMenu", SceneManager.GetActiveScene ().name);


	}
}
