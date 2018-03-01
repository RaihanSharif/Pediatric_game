using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventManager : MonoBehaviour {


    /// <summary>
    /// takes in the scene ID and loads it 
    /// </summary>
    /// <param name="sceneToChangeTo"></param>
	public void ChangeToScene (int sceneToChangeTo) {
		Application.LoadLevel(sceneToChangeTo);
		
	}

    /// <summary>
    /// based on the age value from the slider loads the appropriate subgame
    /// </summary>
	public void ingestionAgeSwitch(){
		if (SliderValueText.ageValue > 5) {
			loadIngestionKid();
		} else {
			loadIngestionBaby();
		}
	}


    /// <summary>
    /// based on the age value from the slider loads the appropriate subgame
    /// </summary>
	public void injectionAgeSwitch(){

		if (SliderValueText.ageValue > 5) {
			loadInjectionKid();
		} else {
			loadInjectionBaby();
		}

	}

    /// <summary>
    /// loads level one ( home menu page ) 
    /// </summary>
	public void goBackToHomePage(){
		Application.LoadLevel(1);
		Debug.Log(SliderValueText.ageValue);
	}		



    /// <summary>
    /// loads level three ( baby ingestion scene )
    /// </summary>
	public void loadIngestionBaby(){
		Application.LoadLevel(3);
	}

    /// <summary>
    /// loads level three ( kid ingestion scene )
    /// </summary>
	public void loadIngestionKid(){
		Application.LoadLevel(4);
	}

    /// <summary>
    /// loads level three ( baby injection scene )
    /// </summary>
	public void loadInjectionBaby(){
		Application.LoadLevel(2);
	}

    /// <summary>
    /// loads level five ( kid injection scene )
    /// </summary>
	public void loadInjectionKid(){
		Application.LoadLevel(5);
	}




		
}
