using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenMouth : MonoBehaviour
{

    public Sprite kidMouthOpen, kidMouthClose;
    public changeFoodOnContact myobj;
    

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
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = kidMouthClose;
        }
	}
}
