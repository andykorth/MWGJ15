using UnityEngine;
using System.Collections;

public class GameManager : SingletonScript<GameManager> {

	public GameObject birdDeadExplosion;
	public GameObject coconutLandingExplosion;
	public GameObject coconutSuccess;

	public GameObject gotACoconut;

	public int points = 0;

	public void GameOver(){

		AddDelayed (1.5f, () => Application.LoadLevel (Application.loadedLevelName)); 
	}

	public void GetPoint ()
	{
		points += 1;
		GameUI.i.UpdateScore (points);
	}

	public void Update(){

		if (Input.GetKeyDown (KeyCode.Space)) {
			Bird.i.DropCoconut ();
		}
			

	}

}
