using UnityEngine;
using System.Collections;

public class MusicManager : SingletonScript<MusicManager> {

	public AudioClip title, gameplay;

	private AudioSource titleSauce, gameSauce;

	// Use this for initialization
	void Start () {
		titleSauce = this.gameObject.AddComponent<AudioSource> ();
		titleSauce.clip = title;
		gameSauce = this.gameObject.AddComponent<AudioSource> ();
		gameSauce.clip = gameplay;

		titleSauce.volume = 0.0f;
		gameSauce.volume = 0.0f;
	}

	public void PlayTitleMusic(){
		SwitchToSource (titleSauce, gameSauce);
	}
	public void PlayGameMusic(){
		SwitchToSource (gameSauce, titleSauce);
	}

	public void SwitchToSource (AudioSource start, AudioSource stop){
		if (!start.isPlaying) {
			start.Play ();
		}

		AddAnimation (1.0f, (a) => {
			start.volume = a;
			stop.volume = 1f - a;
		});
		AddDelayed (1.1f, stop.Stop);
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
