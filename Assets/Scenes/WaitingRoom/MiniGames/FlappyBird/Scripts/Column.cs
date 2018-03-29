using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour 
{


	/// <summary>
	/// this method is called when the bird collides with the column
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.GetComponent<Bird>() != null)
		{
			//If the bird hits the trigger collider in between the columns then
			//tell the game control that the bird scored.
			GameControl.instance.BirdScored();
			AudioSourceBird.instance.playSuccess();
		}
	}
}
