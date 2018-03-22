using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdTesting {


	// test that the velocity is 0 when game is over 
	// test that the bird can score




	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
//	[UnityTest]
//	public IEnumerator FlappyBirdTestingWithEnumeratorPasses() {
//		// Use the Assert class to test conditions.
//		// yield to skip a frame
//		yield return null;
//	}
//
//
//	[Test]
//	public void FlappyBirdTestingSimplePasses() {
//		// Use the Assert class to test conditions.
//		Assert.AreEqual(true, true);
//	}

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
		birdObject.transform.position = new Vector3 (0f, -2f, 0f);
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


	[UnityTest]
	public IEnumerator RestartTheGameTestPasses(){

		LoadSceneByName("FlappyBird");
		yield return null;
		var restartObject = GameObject.Find("Restart");
		yield return new WaitForSeconds(1.5f);
		restartObject = GameObject.Find("Restart");
		restartObject.GetComponent<RestartFlappyBird>().restartTheGame();
		yield return new WaitForSeconds(1f);
		Assert.AreEqual ("FlappyBird", SceneManager.GetActiveScene().name);
		yield return null;
	}


	[UnityTest]
	public IEnumerator MoveToWaitingRoomTestPasses(){

		LoadSceneByName("FlappyBird");
		yield return null;
		var backObject = GameObject.Find("BackButton");
		yield return new WaitForSeconds(1.5f);
		backObject = GameObject.Find("BackButton");
		backObject.GetComponent<ComeBackSprite>().goBackToWaitingRoom();
		yield return new WaitForSeconds(1f);
		Assert.AreEqual ("WaitingRoom", SceneManager.GetActiveScene().name);
		yield return null;
	}



//	[UnityTest]
//	public IEnumerator BirdFlapTestPasses(){
//		LoadSceneByName("FlappyBird");
////		var birdObject = new GameObject().AddComponent<Bird>();
//		yield return null;
//
//		var birdAnimator = GameObject.Find("Bird").GetComponent<Bird>().anim;
////		Debug.Log(birdAnimator.IsInTransition(0));
//		//Debug.Log(birdAnimator.GetLayerIndex("Idle"));
//		//Debug.Log(birdAnimator.GetLayerIndex("Flap"));
//
//		//yield return new WaitForSeconds(5);
//
//		Input.
//
//		yield return new WaitForSeconds(5);
//
//		//Debug.Log(birdAnimator.GetLayerIndex());
//
//		yield return null;
//
//		//Debug.Log(birdAnimator.IsInTransition);
//		Assert.AreEqual(true, birdAnimator.isInitialized);
//
//
//	}


//	[UnityTest]
//	public IEnumerator BirdCollidesTestPasses(){
//
//		var bird = GameObject.Find ("Bird");
//		bird.transform.position = new Vector3 ();
//
//
//	}

	
		

	public void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
		






}
