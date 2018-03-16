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
		//MusicSource.clip = success;
//		MusicSource.Play();
		//MusicSource.PlayOneShot(success);

		
	}

	public void playSuccess(){
		MusicSource.PlayOneShot(success);
	}

	public void playCremeOnSpot(){
		MusicSource.PlayOneShot(cremeSound);
	}

	public void playCremeSpotBecomesWhite(){
		MusicSource.PlayOneShot(CremeSpotBecomesWhite);
	}

	public void playSuccessForInjectionSpot(){
		MusicSource.PlayOneShot(successForInjectionSpot);
	}
}
