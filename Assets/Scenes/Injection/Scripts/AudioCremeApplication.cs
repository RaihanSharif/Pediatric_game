using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCremeApplication : MonoBehaviour {

	public AudioClip cremeSound;
	public AudioClip success;

	public AudioSource MusicSource;

	// Use this for initialization
	void Start (){
		MusicSource.clip = success;
//		MusicSource.Play();

		
	}

}
