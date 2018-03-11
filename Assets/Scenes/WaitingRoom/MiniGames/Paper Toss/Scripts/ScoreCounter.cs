using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public BoxCollider2D scoreIncrementCollider;
	public int score;
	public Text scoreText;

	public System.Random rand = new System.Random();

	void Start(){
		score = 0;
		setScoreText();
	}

	void Update(){
	}

	/// <summary>
	/// Function that is executed when another collider collides with the score increment collider, which is located inside the trash can.
	/// In this case, the "other" collider is the paper ball's collider.
	/// It increments the score and updates the text displaying the score. After that it waits 2 seconds with 
	/// "yield return new WaitForSeconds(2);", which is why the function is of type IEnumerator. This is so the ball does not respawn instantly.
	/// Finally, it generates a random number between -200 and 250, which is the range of the x-axis within the screen, so the x position of the ball becomes that.
	/// </summary>
	/// <param name="other">Other.</param>
	IEnumerator OnTriggerEnter2D(Collider2D other){

		score++;
		setScoreText();

		yield return new WaitForSeconds(2);

		int randInt = rand.Next(-200, 250);
		// translates the paper ball by randInt in the x position and transform.position.y-90f in the y position, which are the values that put the ball randomly across the bottom of the image
		other.gameObject.transform.Translate(new Vector3(randInt, transform.position.y-90f), Space.World);

	}

	/// <summary>
	/// Updates the display of the score in the top left of the scene.
	/// </summary>
	void setScoreText(){
		scoreText.text = "Score: " + score.ToString();
	}

}
