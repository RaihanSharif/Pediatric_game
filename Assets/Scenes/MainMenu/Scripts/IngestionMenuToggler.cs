using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngestionMenuToggler : MonoBehaviour {

	[SerializeField]
	private GameObject ingestionMenu;

	void Start(){
		ingestionMenu.SetActive(false);
	}

	public void toggleIngestionMenu(){
		ingestionMenu.SetActive(true);
	}
}
