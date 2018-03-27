using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingRoomSounds : MonoBehaviour {

	public AudioClip ninjaAttack;
	public AudioClip birdSound;
	public AudioSource MusicSource;


	/// <summary>
	/// Plays the bird.
	/// </summary>
	public void playBird(){
		MusicSource.PlayOneShot(birdSound);
	}


	/// <summary>
	/// Plays the ninja.
	/// </summary>
	public void playNinja(){
		MusicSource.PlayOneShot(ninjaAttack);
	}
}
