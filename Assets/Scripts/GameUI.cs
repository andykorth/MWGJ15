using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : SingletonScript<GameUI> {

	public Text scoreText;

	public GameObject pausePanel;
	private bool paused = false;

	public Text invertText;

	public void ToggleInvert(){
		PlayerPrefs.SetInt ("Inverted", PlayerPrefs.GetInt ("Inverted", 1) == 1 ? 0 : 1);
		UpdateInvertText ();
	}

	public void UpdateInvertText(){
		bool b = PlayerPrefs.GetInt ("Inverted", 1) == 1;
		invertText.text = b ? "Inverted Y-axis" : "Non-inverted Y-axis";
		Bird.i.CheckInvert ();
	}

	public void TogglePausePanel(){
		paused = !paused;
		pausePanel.SetActive (paused);
		GameManager.i.paused = paused;
		UpdateInvertText ();
	}

	public void UnPause(){
		TogglePausePanel ();
	}

	public void UpdateScore(int score){
		scoreText.text = "Score: " + score;
	}
}
