using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheBird : MonoBehaviour {

	public WaitingRoomSounds roomSounds;
	private int counter = 0;


	public void OnMouseDown(){
		if (!PauseMenu.isPaused){
			SceneManager.LoadScene("FlappyBird");
        	WaitingRoomData.currentBarAmount -= RadialProgressBar.DECREASEBARAMOUNT;
		}
    }


	public void playBirdSound(){
		if (counter % 5 == 0) {
			roomSounds.playBird ();
		}
		counter++;

	}
}
