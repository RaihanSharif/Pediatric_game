using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInjectionGame : MonoBehaviour {

	public Syringe syringe;

	public void RemoveButtonAndShowSyringe(){
		syringe.gameObject.SetActive (true);
		this.gameObject.SetActive(false);

	}
}
