using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour {

//	public SliderValueText sliderText;

	[SerializeField]
	[Tooltip("The text shown will be formatted using this string.  {0} is replaced with the actual value")]
	public string formatText = "{0} years";


	// Update is called once per frame
	public void ChangeToScene (int sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
		
	}
		
	public void LoadAppropriateIngestionScene(){

		if (SliderValueText.ageValue > 5) {
			LoadIngestionSceneForKid();
		} else {
			LoadIngestionSceneForBaby();
		}

	}

	public void LoadAppropriateInjectionScene(){

		if (SliderValueText.ageValue > 5) {
			LoadInjectionSceneForKid();
		} else {
			LoadInjectionSceneForBaby();
		}

	}

	public void goBackToHomePage(){
		Application.LoadLevel(1);
		SliderValueText.tmproText.text = string.Format(formatText, SliderValueText.ageValue);
		Debug.Log(SliderValueText.ageValue);
	}		
		

	public void LoadIngestionSceneForBaby(){
		Application.LoadLevel(3);
	}


	public void LoadIngestionSceneForKid(){
		Application.LoadLevel(4);
	}

	public void LoadInjectionSceneForBaby(){
		Application.LoadLevel(2);
	}


	public void LoadInjectionSceneForKid(){
		Application.LoadLevel(5);
	}




		
}
