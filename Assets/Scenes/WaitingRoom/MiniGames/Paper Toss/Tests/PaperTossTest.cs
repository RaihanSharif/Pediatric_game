using UnityEngine;
//using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaperTossTest {

	private void LoadSceneByName(string name){
		
		SceneManager.LoadScene(name, LoadSceneMode.Single);

	}

	/// <summary>
	/// Checks whether the score increases
	/// when the ball touches the score collider.
	/// </summary>
	/// <returns>If the actual score matches the expected score of 1.</returns>
	[UnityTest]
	public IEnumerator BallEntersTrashScoreIncreases(){

		LoadSceneByName("PaperTossScene");
		yield return null;

		var ball = GameObject.Find("PaperBall");
		ball.transform.position = new Vector3(245f, 100f, -0.5f);

		yield return new WaitForSeconds(5f);

		var collider = GameObject.Find("ScoreIncrementerCollider");
		var colliderscript = collider.GetComponent<ScoreCounter>();

		Assert.AreEqual(1, colliderscript.score);

	}

	/// <summary>
	/// Checks whether the text that displays the score updates
	/// when the ball touches the score collider.
	/// </summary>
	/// <returns>If the actual score display text matches the expected string.</returns>
	[UnityTest]
	public IEnumerator BallEntersTrashTextUpdates(){

		LoadSceneByName("PaperTossScene");
		yield return null;

		var ball = GameObject.Find("PaperBall");
		ball.transform.position = new Vector3(245f, 100f, -0.5f);

		yield return new WaitForSeconds(5f);

		var collider = GameObject.Find("ScoreIncrementerCollider");
		var colliderscript = collider.GetComponent<ScoreCounter>();

		Assert.AreEqual("Score: 1", colliderscript.scoreText.text);

	}

	/// <summary>
	/// Tests whether there is a delay after the ball touches the score collider
	/// by checking if the y coordinate is above 50. This is because the ball respawns to a point below y = 50.
	/// </summary>
	/// <returns>If the actual position of the ball has a y position of over 50.</returns>
	[UnityTest]
	public IEnumerator BallEntersTrashDelayHappens(){

		LoadSceneByName("PaperTossScene");
		yield return null;

		var ball = GameObject.Find("PaperBall");
		ball.transform.position = new Vector3(245f, 100f, -0.5f);

		yield return new WaitForSeconds(0.75f);

		var collider = GameObject.Find("ScoreIncrementerCollider");
		var colliderscript = collider.GetComponent<ScoreCounter>();

		Assert.AreEqual(true, ball.transform.position.y > 50);

	}

	/// <summary>
	/// Tests whether a force applied to a ball changes its position.
	/// </summary>
	/// <returns>If the actual position is different than the first recorded position.</returns>
	[UnityTest]
	public IEnumerator ForceChangesBallPos() {

		LoadSceneByName("PaperTossScene");
		yield return null;

		var ball = GameObject.Find("PaperBall").GetComponent<Rigidbody2D>();
		yield return new WaitForSeconds(2);

		var firstPos = ball.transform.position;
		var ballscript = ball.gameObject.GetComponent<PaperBallBehaviour>();
		ballscript.setValuesForTesting();
		ballscript.calculatePaperBallForce();
		yield return new WaitForSeconds(0.5f);

		Assert.AreNotEqual(firstPos, ball.transform.position);

	}

	/// <summary>
	/// Makes sure that when a force of 0 is applied to the ball,
	/// then it does not move.
	/// </summary>
	/// <returns>If the actual position is the same as the first recorded position.</returns>
	[UnityTest]
	public IEnumerator NoForceDoesNotChangeBallPos() {

		LoadSceneByName("PaperTossScene");
		yield return null;

		var ball = GameObject.Find("PaperBall").GetComponent<Rigidbody2D>();
		yield return new WaitForSeconds(2);

		var firstPos = ball.transform.position;
		ball.AddForce(new Vector2(0, 0));
		yield return new WaitForSeconds(0.5f);

		Assert.AreEqual(firstPos, ball.transform.position);

	}

	/// <summary>
	/// Makes sure that a force is not applied to the ball
	/// when there is a swipe and the ball is over the y position of 115.
	/// </summary>
	/// <returns>If ball moves when it's over y 115.</returns>
	[UnityTest]
	public IEnumerator ForceDoesNotChangeBallPosOverY115() {

		LoadSceneByName("PaperTossScene");
		yield return null;

		var ball = GameObject.Find("PaperBall").GetComponent<Rigidbody2D>();
		ball.transform.position = new Vector3(214f, 130f, -0.5f);
		yield return new WaitForSeconds(2);

		var firstPos = ball.transform.position;
		var ballscript = ball.gameObject.GetComponent<PaperBallBehaviour>();
		ballscript.setValuesForTesting();
		ballscript.calculatePaperBallForce();
		yield return new WaitForSeconds(0.5f);

		Assert.AreEqual(firstPos, ball.transform.position);

	}

	/// <summary>
	/// Makes sure that the throw force (taken into account when 
	/// calculating the movement of the ball) hasn't been changed.
	/// </summary>
	/// <returns>If the force is the expected constant.</returns>
	[UnityTest]
	public IEnumerator ForceConstantDoesNotChange() {

		var thePaperBall = new GameObject().AddComponent<PaperBallBehaviour>();

		Assert.AreEqual(3f, thePaperBall.throwForce);

		yield return null;

	}

}
	