using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

	public BoxCollider2D scoreIncrementCollider;
	public int score = 0;
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		
		score++;
		Wait();
		other.gameObject.transform.Translate(new Vector3((2.6f - transform.position.x), (-transform.position.y)));

		Debug.Log(score);
			
	}

	IEnumerator Wait(){
		Debug.Log("AAaaaaaaaaah!");
		yield return new WaitForSeconds(3);
		Debug.Log("Ddfblkbbdfblbfadjhvdsjkhv!");
	}
}
