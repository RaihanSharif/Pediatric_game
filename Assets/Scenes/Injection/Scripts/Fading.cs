using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

	/// <summary>
	/// move to the next scene (success is displayed)
	/// </summary>

	[SerializeField]
	private LevelFinishedMenu lvlFM;

	[SerializeField]
	private GameObject scoreSlider;


	/// <summary>
	/// Moves to next scene.
	/// </summary>
	public void moveToNextScene(){
		if (SceneManager.GetActiveScene ().name == "CremeApplication") {
            SceneManager.LoadScene("InjectionBaby", LoadSceneMode.Single);

        }
        else if(SceneManager.GetActiveScene ().name == "InjectionBaby"){
        	scoreSlider.SetActive(false);
            lvlFM.OnLevelFinished();

        }

    }
}
