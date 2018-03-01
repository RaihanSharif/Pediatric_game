using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {


	[SerializeField]
	[Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
	public string formatText = "{0} years"; // format of the text displayed above the slider


	// Update is called once per frame
	public void ChangeToScene (int sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
		
	}

	/// <summary>
	/// the ingestion scene loaded is different depending on the age selected (more than 5 -> kid game and less than 5 -> baby game )
	/// </summary>
	public void LoadAppropriateIngestionScene(){

		if (SliderValueText.ageValue > 5) {
			LoadIngestionSceneForKid();
		} else {
			LoadIngestionSceneForBaby();
		}

	}

	/// <summary>
	/// the ingestion scene loaded is different depending on the age selected (more than 5 -> kid game and less than 5 -> baby game )
	/// </summary>
	public void LoadAppropriateInjectionScene(){

		if (SliderValueText.ageValue > 5) {
			LoadInjectionSceneForKid();
		} else {
			LoadInjectionSceneForBaby();
		}

	}
	/// <summary>
	/// loads the home page.
	/// </summary>
	public void goBackToHomePage(){
		Application.LoadLevel(1);
		SliderValueText.tmproText.text = string.Format(formatText, SliderValueText.ageValue);
		Debug.Log(SliderValueText.ageValue);
	}		
		
	/// <summary>
	/// Loads the ingestion scene for baby.
	/// </summary>
	public void LoadIngestionSceneForBaby(){
		Application.LoadLevel(3);
	}

	/// <summary>
	/// Loads the ingestion scene for kid.
	/// </summary>
	public void LoadIngestionSceneForKid(){
		Application.LoadLevel(4);
	}

	/// <summary>
	/// Loads the injection scene for baby.
	/// </summary>
	public void LoadInjectionSceneForBaby(){
		Application.LoadLevel(2);
	}

	/// <summary>
	/// Loads the injection scene for kid.
	/// </summary>
	public void LoadInjectionSceneForKid(){
		Application.LoadLevel(5);
	}




		
}
