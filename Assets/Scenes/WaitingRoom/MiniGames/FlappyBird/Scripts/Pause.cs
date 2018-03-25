using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public PauseMenu pauseMenu;

    void OnMouseDown()
    {
        pauseMenu.Pause();
        Debug.Log("amine");
    }

}
