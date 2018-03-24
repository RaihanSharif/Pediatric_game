using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour {

    public void triggerMenuBehaviour ( int i)
    {
        switch(i)
        {
            // by default case is 0
            default:
            case (0):
                SceneManager.LoadScene("CardMatchingGame");
                break;

            case (1):
                Application.Quit();
                break;
        }
    }
}
