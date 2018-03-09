using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

	public BoxCollider2D scoreIncrementCollider;
	public int score;
	public Text scoreText;

	public System.Random r = new System.Random();

	void Start(){
		score = 0;
		setScoreText();
	}

	void Update(){
	}

	IEnumerator OnTriggerEnter2D(Collider2D other){

		score++;
		setScoreText();

		yield return new WaitForSeconds(2);

		int rInt = r.Next(-200, 250);
		other.gameObject.transform.Translate(new Vector3(rInt, transform.position.y-90f), Space.World); //instead of 250f you could use a randomiser between -200 and 250.

	}

	void setScoreText(){
		scoreText.text = "Score: " + score.ToString();
	}

}
