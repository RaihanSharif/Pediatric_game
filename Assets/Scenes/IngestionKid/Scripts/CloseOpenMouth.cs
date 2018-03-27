using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenMouth : MonoBehaviour
{

    public Sprite kidMouthOpen, kidMouthClose;
    public changeFoodOnContact myobj;
    

    /// <summary>
    /// at the start of the game the kid closing mouth is being loaded 
    /// </summary>
    void Start () {
        this.GetComponent<SpriteRenderer>().sprite = kidMouthClose;
    }
	
	/// <summary>
    /// for every second we want to check if the mouoth of the kid is open or not ( the boolean flag ) and if it is true then 
    /// load the sprite with the kid mouth is opened and otherwise load the sprite with the kids mouth being closed. 
    /// </summary>
	void Update ()
    {
		if(myobj.isMouthOpen)
        {
            this.GetComponent<SpriteRenderer>().sprite = kidMouthOpen;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = kidMouthClose;
        }
	}
}
