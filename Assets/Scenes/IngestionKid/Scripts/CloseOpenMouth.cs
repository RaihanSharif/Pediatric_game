using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenMouth : MonoBehaviour
{

	public Sprite kidMouthOpen, kidMouthClose;
	public changeFoodOnContact myobj;
	private int counter=0;
	private bool incrementCounter = true;
	public LevelFinishedMenu lvlFM; //Reference to the event manager



	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().sprite = kidMouthClose;
	}

	// Update is called once per frame
	void Update ()
	{
		if(myobj.isMouthOpen)
		{
			this.GetComponent<SpriteRenderer>().sprite = kidMouthOpen;
			incrementCounter = true;
		}
		else
		{
			this.GetComponent<SpriteRenderer>().sprite = kidMouthClose;
			if (incrementCounter == true) {
				incrementTheCounter ();
			}
		}
	}

	/// <summary>
	/// Increments the counter.
	/// </summary>
	private void incrementTheCounter(){
		counter++;
		incrementCounter = false;
		if (counter == 11) {
			lvlFM.OnLevelFinished();// display success window
		}

	}

}
