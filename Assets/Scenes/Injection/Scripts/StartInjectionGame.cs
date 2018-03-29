using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInjectionGame : MonoBehaviour {

	public Syringe syringe;

	/// <summary>
	/// Removes the button and show syringe on the arm of the kid.
	/// </summary>
	public void RemoveButtonAndShowSyringe(){
		syringe.gameObject.SetActive (true);
		this.gameObject.SetActive(false);

	}
}
