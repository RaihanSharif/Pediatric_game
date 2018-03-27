using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandBag2 : MonoBehaviour {

	public GameObject bag1;
	public GameObject bag2;
	public GameObject realBag1;
	public GameObject realBag2;
    public GameObject realStrap1;
    public GameObject realStrap2;

    public void enableBoxColliders()
    {
		realBag1.GetComponent<SpriteRenderer>().enabled = true;
        realBag1.GetComponent<BoxCollider2D>().enabled = true;
		realBag2.GetComponent<SpriteRenderer>().enabled = true;
        realBag2.GetComponent<BoxCollider2D>().enabled = true;
        realStrap1.GetComponent<BoxCollider2D>().enabled = true;
        realStrap2.GetComponent<BoxCollider2D>().enabled = true;
        bag1.SetActive(false);
		bag2.SetActive(false);
	}
}
