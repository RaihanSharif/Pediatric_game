using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceBird : MonoBehaviour {

	public static AudioSourceBird instance;	//A reference to our audio bird script so we can access it statically.

	public AudioClip success;
	public AudioClip flap;
	public AudioSource MusicSource;



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

	public void playSuccess(){
		MusicSource.PlayOneShot(success);
	}

	public void playFlap(){
		MusicSource.PlayOneShot(flap);
	}


}
