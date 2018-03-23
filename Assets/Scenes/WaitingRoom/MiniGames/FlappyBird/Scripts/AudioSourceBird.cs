using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceBird : MonoBehaviour {

	public static AudioSourceBird instance;	//A reference to our audio bird script so we can access it statically.

	public AudioClip success;
	public AudioClip flap;
	public AudioClip collision;
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


	/// <summary>
	/// Plays the success sound.
	/// </summary>
	public void playSuccess(){
		MusicSource.PlayOneShot(success);
	}

	/// <summary>
	/// Plays the flap sound.
	/// </summary>
	public void playFlap(){
		MusicSource.PlayOneShot(flap);
	}


	/// <summary>
	/// Plays the collision sound.
	/// </summary>
	public void playCollision(){
		MusicSource.PlayOneShot(collision);
	}

}
