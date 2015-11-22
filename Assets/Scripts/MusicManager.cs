using UnityEngine;
using System.Collections;

public class MusicManager : SingletonScript<MusicManager> {

	public AudioClip title, gameplay;

	private AudioSource titleSauce, gameSauce;

	public AudioClip menuClick;
	public AudioClip gameOver, getCoconut, launchCoconut, birdExplosion, coconutMiss;

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
			start.volume = (a) * 0.5f;
			stop.volume = (1f - a) * 0.5f;
		});
		AddDelayed (1.1f, stop.Stop);
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	public static void PlayClip(AudioClip clip){
		if(clip == null) return;
		GameObject newClip = new GameObject(clip.name + " Instantiation");
		newClip.AddComponent(typeof(AudioSource));
		newClip.GetComponent<AudioSource>().clip = clip;

		newClip.GetComponent<AudioSource>().Play();
		Object.Destroy(newClip, clip.length + 0.5f);
	}


}
