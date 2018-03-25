using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeckOfCards : MonoBehaviour {


    public void OnMouseDown()
    {
        if (!PauseMenu.isPaused)
        {
            SceneManager.LoadScene("CardMatchingGameMenu");
            WaitingRoomData.currentBarAmount -= RadialProgressBar.DECREASEBARAMOUNT;
        }
    }




}
