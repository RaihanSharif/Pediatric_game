using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdIntegrationTesting {


	[UnityTest]
	public IEnumerator gameIsOverTestPasses(){
		LoadSceneByName("FlappyBird");
		yield return null;
		var gameControlObject = GameObject.Find("GameControl");
		yield return new WaitForSeconds(1f);
		Assert.AreEqual (gameControlObject.GetComponent<GameControl>().gameOver, true);


	}

	[UnityTest]
	public IEnumerator VelocityIs0WhenGameIsOverTestPasses(){
		LoadSceneByName("FlappyBird");
		yield return null;
		var birdObject = GameObject.Find("Bird");
		birdObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 250));
		yield return new WaitForSeconds(2f);
		Assert.AreEqual(birdObject.GetComponent<Rigidbody2D>().velocity, Vector2.zero);

	}



	[UnityTest]
	public IEnumerator ScrollSpeedTestPasses(){

		var controlGame = new GameObject().AddComponent<GameControl>();
		Assert.AreEqual(-1.5f, controlGame.scrollSpeed);

		yield return null;
	}


	[UnityTest]
	public IEnumerator FlappyBirdCollidesWithGroundTestPasses(){

		LoadSceneByName("FlappyBird");
		yield return null;
		var birdObject = GameObject.Find("Bird");
		birdObject.transform.position = new Vector3 (1f, -2f, 0f);
		yield return new WaitForSeconds (0.2f);
		Assert.AreEqual(true, birdObject.GetComponent<Bird>().isDead);
		yield return null;

	}


	[UnityTest]
	public IEnumerator UpForceTestPasses(){

		LoadSceneByName("FlappyBird");
		yield return null;
		var birdObject = GameObject.Find("Bird");
		Debug.Log(birdObject.GetComponent<Bird>().upForce);
		Assert.AreEqual(250f, birdObject.GetComponent<Bird>().upForce);
		yield return null;
	}






	public void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
}
