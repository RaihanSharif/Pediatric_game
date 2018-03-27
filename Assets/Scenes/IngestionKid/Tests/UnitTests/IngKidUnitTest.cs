using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngKidUnitTest {

	private void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	/// <summary>
	/// Short test that checks whether the kid's
	/// mouth is closed when the secene starts.
	/// </summary>
	[Test]
	public void KidMouthIsClosedAtStartPasses() {
		var kid = new GameObject ().AddComponent<changeFoodOnContact> ();
		Assert.AreEqual (false, kid.isMouthOpen);
	}

	/// <summary>
	/// Short test that checks whether the spoon doesn't
	/// pick up any food if it's in the wrong position
	/// </summary>
	[UnityTest]
	public IEnumerator SpoonTakesFoodFails() {
		LoadSceneByName("IngestionKid");
		yield return null;

		yield return new WaitForSeconds (10);

		var spoon = GameObject.FindGameObjectWithTag("Spoon");
		spoon.transform.position = new Vector3(-4.5f, -3.5f, 0f);
		yield return new WaitForSeconds (1);
		var food = GameObject.Find ("food");
		var script = food.GetComponent<changeFoodOnContact> ();

		Assert.AreEqual (false, script.isMouthOpen);
	}

	/// <summary>
	/// The spoon picks up food and then goes to the wrong position
	/// to feed it to the kid, checks whether this is true.
	/// </summary>
	[UnityTest]
	public IEnumerator SpoonTakesFoodThenKidEatsFails() {
		LoadSceneByName("IngestionKid");
		yield return null;

		yield return new WaitForSeconds (10);

		var spoon = GameObject.FindGameObjectWithTag("Spoon");
		spoon.transform.position = new Vector3(-3.87f, 0.37f, 0f);
		yield return new WaitForSeconds (1);
		spoon.transform.position = new Vector3 (4.8f, -2.2f, 0f);
		yield return new WaitForSeconds (1);
		var food = GameObject.Find ("food");
		var script = food.GetComponent<changeFoodOnContact> ();

		Assert.AreEqual (true, script.isMouthOpen);
	}

	/// <summary>
	/// Makes spoon and food collide, checks
	/// whether kid's mouth opens as a result.
	/// </summary>
	[UnityTest]
	public IEnumerator KidMouthOpensAfterCollisionPasses() {
		LoadSceneByName("IngestionKid");
		yield return null;

		yield return new WaitForSeconds (10);

		var spoon = GameObject.FindGameObjectWithTag("Spoon");
		spoon.transform.position = new Vector3(-3.87f, 0.37f, 0f);
		yield return new WaitForSeconds (1);

		var food = GameObject.Find ("food");
		var script = food.GetComponent<changeFoodOnContact> ();

		Assert.AreEqual (true, script.isMouthOpen);
	}

	/// <summary>
	/// Checks whether the spoon can pickup the food 
	/// then feed it to the kid correctly.
	/// </summary>
	[UnityTest]
	public IEnumerator KidMouthOpenThenClosePasses() {
		LoadSceneByName ("IngestionKid");
		yield return null;

		yield return new WaitForSeconds (10);

		var spoon = GameObject.Find ("spoon");
		spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
		yield return new WaitForSeconds (1);
		spoon.transform.position = new Vector3 (4.9f, 0.001f, 0f);
		yield return new WaitForSeconds (1);

		var food = GameObject.Find ("food");
		var script = food.GetComponent<changeFoodOnContact> ();

		Assert.AreEqual (false, script.isMouthOpen);
	}

	/// <summary>
	/// Checks whether the kid is able to eat
	/// all the food except the very last bit
	/// </summary>
	[UnityTest]
	public IEnumerator KidEatsAllFoodPasses() {
		LoadSceneByName ("IngestionKid");
		yield return null;

		yield return new WaitForSeconds (10);

		var spoon = GameObject.Find ("spoon");
		for (int i = 0; i < 10; i++) {
			spoon.transform.position = new Vector3 (-3.87f, 0.37f, 0f);
			yield return new WaitForSeconds (0.1f);
			spoon.transform.position = new Vector3 (4.9f, 0.001f, 0f);
			yield return new WaitForSeconds (0.1f);
		}
		var food = GameObject.Find ("food");
		var script = food.GetComponent<changeFoodOnContact> ();
		Assert.AreEqual (false, script.isMouthOpen);
	}


}
