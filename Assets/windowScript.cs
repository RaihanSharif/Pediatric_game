using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class windowScript : MonoBehaviour {

	// Use this for initialization
	void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown()
    {
        Debug.Log("well done u pressed me");
        SceneManager.LoadScene(1);
    }

}
