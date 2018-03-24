using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public BoxCollider2D scoreIncrementCollider; // collider object that checks if the paper ball entered the trash can
	public int score;
	public Text scoreText; // text that displays the score on the screen

	public System.Random rand = new System.Random(); // random object used to generate a random number

	void Start(){

		score = 0;
		updateScoreText();

	}

	void Update(){}

	/// <summary>
	/// Updates the display of the score in the top left of the scene.
	/// </summary>
	void updateScoreText(){
		scoreText.text = "Score: " + score.ToString();
	}

	/// <summary>
	/// Produces a random number.
	/// </summary>
	/// <returns>The random number</returns>
	int getRandNum(){
		int randInt = rand.Next(-200, 250);
		return randInt;
	}

	/// <summary>
	/// Translates the game object to which the collider belongs. In this case, the paper ball.
	/// </summary>
	/// <param name="toBeTranslated">Collider of the game object to be translated</param>
	void translatePaperBall(Collider2D toBeTranslated){

		toBeTranslated.gameObject.transform.Translate(new Vector3(getRandNum(), -200f), Space.World);

	}

	/// <summary>
	/// Updates the score and display, then delays for 1.2 seconds so the ball does not respawn instantly.
	/// Finally, it translates the paper ball by randInt in the x position and transform.position.y-90f in the y position, 
	/// which are the values that put the ball randomly across the bottom of the scene.
	/// </summary>
	/// <param name="other">the other collider</param>
	IEnumerator OnTriggerEnter2D(Collider2D other){

		score++;
		updateScoreText();

		yield return new WaitForSeconds(1.2f); // wait 1.2 seconds

		translatePaperBall(other);

	}

}
		