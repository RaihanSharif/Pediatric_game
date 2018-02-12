using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public int num;
	
	//<param name="abcd>comment about param</param>
	/// <summary>
	/// On click transitions from start scence to menu scene

	/// </summary>
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(num+1);
            Debug.Log("Scene changed to " + num);
        }
    }
}
