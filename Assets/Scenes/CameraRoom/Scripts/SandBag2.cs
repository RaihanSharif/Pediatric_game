using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag2 : MonoBehaviour {

	public GameObject bag1;
	public GameObject bag2;
	public GameObject realBag1;
	public GameObject realBag2;


	void Start(){


	}

	
	public void enableBoxColliders(){

		realBag1.GetComponent<SpriteRenderer>().enabled = true;
		realBag2.GetComponent<SpriteRenderer>().enabled = true;
		bag1.SetActive(false);
		bag2.SetActive(false);
		




	}
}
