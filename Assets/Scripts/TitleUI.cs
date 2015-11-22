using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour {

	public Text invertText;

	public void ToggleInvert(){
		PlayerPrefs.SetInt ("Inverted", PlayerPrefs.GetInt ("Inverted", 1) == 1 ? 0 : 1);
		UpdateInvertText ();
	}

	public void UpdateInvertText(){
		bool b = PlayerPrefs.GetInt ("Inverted", 1) == 1;
		invertText.text = b ? "Inverted Y-axis" : "Non-inverted Y-axis";
	}

	public void Start(){
		MusicManager.i.PlayTitleMusic ();
		UpdateInvertText ();
	}
		

	public void PlayGame(){
		Application.LoadLevel ("Game");
	}
}
