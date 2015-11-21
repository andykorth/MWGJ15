using UnityEngine;
using System.Collections;

public class GameManager : SingletonScript<GameManager> {

	public GameObject birdDeadExplosion;
	public GameObject coconutLandingExplosion;

	public GameObject gotACoconut;

	public void GameOver(){

		AddDelayed (1.5f, () => Application.LoadLevel (Application.loadedLevelName)); 
	}
}
