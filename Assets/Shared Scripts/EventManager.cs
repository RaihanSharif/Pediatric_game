
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EventManager : MonoBehaviour {

	//Int constants for ingestion and injection
	public const int INGESTION = 1;
	public const int INJECTION = 2;
	//Int flag for selecting the procedure
	private int procedureSelected;

	//Int constants for age
	public const int BABY = 1;
	public const int KID = 2;
	//Flag for selecting the age
	private int ageSelected;

	//Loads a scene with a specific name
	public void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	//Sets age flag, checks if procedure has been selected and if yes loads appropriate level 
	public void babyButtonPressed(){
		ageSelected = BABY;
		if (procedureSelected == INGESTION){
			LoadSceneByName("IngestionBaby");
		}
		if (procedureSelected == INJECTION){
			LoadSceneByName("InjectionKid");
		}
	}

	//Sets age flag, checks if procedure has been selected and if yes loads appropriate level 
	public void kidButtonPressed(){
		ageSelected = KID;
		if (procedureSelected == INGESTION){
			LoadSceneByName("IngestionKid");
		}
		if (procedureSelected == INJECTION){
			LoadSceneByName("InjectionKid");
		}
		
	}

	//Sets procedure flag, checks if age has been selected and if yes loads appropriate level 
	public void ingestionButtonPressed(){
		procedureSelected = INGESTION;
		if (ageSelected == BABY){
			LoadSceneByName("IngestionBaby");
		}
		if (ageSelected == KID){
			LoadSceneByName("IngestionKid");
		}
	}

	//Sets procedure flag, checks if age has been selected and if yes loads appropriate level 
	
	public void injectionButtonPressed(){
		procedureSelected = INJECTION;
		if (ageSelected == BABY  || ageSelected == KID){
			LoadSceneByName("InjectionKid");
		}
		
	}

}

