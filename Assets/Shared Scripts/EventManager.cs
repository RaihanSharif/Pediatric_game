
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
	public static string chosenScene;

	//Loads a scene with a specific name
	public void LoadSceneByName(string name){

		SceneManager.LoadScene(name, LoadSceneMode.Single);
	}

	//Loads the scene chosen in the main menu
	public void LoadChosenScene(){

		SceneManager.LoadScene(chosenScene, LoadSceneMode.Single);
	}

	//Sets age flag, checks if procedure has been selected and if yes loads appropriate level 
	public void babyButtonPressed(){
		ageSelected = BABY;
		if (procedureSelected == INGESTION){
			LoadSceneByName("ProcedureExplanation");
			chosenScene = "IngestionBaby";
		}
		if (procedureSelected == INJECTION){
			LoadSceneByName("ProcedureExplanation");
			chosenScene = "CremeApplication";
		}
	}
		

	//Sets age flag, checks if procedure has been selected and if yes loads appropriate level 
	public void kidButtonPressed(){
		ageSelected = KID;
		if (procedureSelected == INGESTION){
			LoadSceneByName("ProcedureExplanation");
			chosenScene = "IngestionKid";
		}
		if (procedureSelected == INJECTION){
			LoadSceneByName("ProcedureExplanation");
			chosenScene = "CremeApplication";
		}
		
	}

	//Sets procedure flag, checks if age has been selected and if yes loads appropriate level 
	public void ingestionButtonPressed(){
		procedureSelected = INGESTION;
		if (ageSelected == BABY){
			LoadSceneByName("ProcedureExplanation");
			chosenScene = "IngestionBaby";
		}
		if (ageSelected == KID){
			LoadSceneByName("ProcedureExplanation");
			chosenScene = "IngestionKid";
		}
	}

	//Sets procedure flag, checks if age has been selected and if yes loads appropriate level 
	
	public void injectionButtonPressed(){
		procedureSelected = INJECTION;
		LoadSceneByName("ProcedureExplanation");
		chosenScene = "CremeApplication";
		
	}

}

