using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameUI : SingletonScript<GameUI> {

	public Text scoreText;



	public void UpdateScore(int score){
		scoreText.text = "Score: " + score;
	}
}
