using UnityEngine;
using System.Collections;

public class TitleUI : MonoBehaviour {


	public void Start(){
		MusicManager.i.PlayTitleMusic ();
	}


	public void PlayGame(){
		Application.LoadLevel ("Game");
	}
}
