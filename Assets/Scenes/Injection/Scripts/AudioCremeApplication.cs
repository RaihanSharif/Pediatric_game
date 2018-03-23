using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCremeApplication : MonoBehaviour {

	public AudioClip cremeSound;
	public AudioClip success;
	public AudioClip successForInjectionSpot;
	public AudioClip CremeSpotBecomesWhite;

	public AudioSource MusicSource;

	// Use this for initialization
	void Start (){

	}

	/// <summary>
	/// Plays the success.
	/// </summary>
	public void playSuccess(){
		MusicSource.PlayOneShot(success);
	}

	/// <summary>
	/// Plays the creme on spot.
	/// </summary>
	public void playCremeOnSpot(){
		MusicSource.PlayOneShot(cremeSound);
	}


	/// <summary>
	/// Plays the creme spot becomes white.
	/// </summary>
	public void playCremeSpotBecomesWhite(){
		MusicSource.PlayOneShot(CremeSpotBecomesWhite);
	}


	/// <summary>
	/// Plays the success for injection spot.
	/// </summary>
	public void playSuccessForInjectionSpot(){
		MusicSource.PlayOneShot(successForInjectionSpot);
	}
}
