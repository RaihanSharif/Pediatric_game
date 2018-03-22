using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TheBird : MonoBehaviour {

	public void OnMouseDown(){
        SceneManager.LoadScene("FlappyBird");
        WaitingRoomData.currentBarAmount -= RadialProgressBar.DECREASEBARAMOUNT;

    }
}
