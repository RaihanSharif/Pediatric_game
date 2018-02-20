using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SplashScreen : MonoBehaviour {

	public Image exampleImage;
	public string imageToLoad;

	public void Start(){
		exampleImage.sprite = (Sprite)Resources.Load<Sprite>(imageToLoad) as Sprite;

	}


}
