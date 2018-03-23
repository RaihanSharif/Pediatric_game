using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlappyBirdUnitTesting {


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


	public void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}
}
