using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SplashScreen : MonoBehaviour {

	public Image exampleImage; // image to load as a background
	public string imageToLoad; // path to the image file 

	public void Start(){
		exampleImage.sprite = (Sprite)Resources.Load<Sprite>(imageToLoad) as Sprite; // load the sprite image from the path 

	}


}
