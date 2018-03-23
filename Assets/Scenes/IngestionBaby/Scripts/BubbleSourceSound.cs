using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSourceSound : MonoBehaviour {

	public static BubbleSourceSound instance;	//A reference to our audio bird script so we can access it statically.
	public AudioSource MusicSource;
	public AudioClip bubble;



	void Awake()
	{
		//If we don't currently have a game control...
		if (instance == null)
			//...set this one to be it...
			instance = this;
		//...otherwise...
		else if(instance != this)
			//...destroy this one because it is a duplicate.
			Destroy (gameObject);

	}


	public void playBubbleSound(){
		MusicSource.PlayOneShot(bubble);
	}

}
