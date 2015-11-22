using UnityEngine;
using System.Collections;

public class GameManager : SingletonScript<GameManager> {

	public GameObject birdDeadExplosion;
	public GameObject coconutLandingExplosion;
	public GameObject coconutSuccess;

	public GameObject gotACoconut;

	public Transform nests;
	public Transform rings;

	public int points = 0;

	public bool paused = false;

	public void Start(){
		MusicManager.i.PlayGameMusic ();
		UpdateNestRingCombo ();
	}

	public void GameOver(){

		AddDelayed (1.5f, () => Application.LoadLevel (Application.loadedLevelName)); 
	}

	public void GetPoint ()
	{
		points += 1;
		GameUI.i.UpdateScore (points);

		UpdateNestRingCombo ();
	}

	public void UpdateNestRingCombo(){
		ActivateOneIn (nests);
		ActivateOneIn (rings);
	}

	public void ActivateOneIn(Transform parent){
		int target = Random.Range(0,parent.childCount);
		for(int i= 0; i < parent.childCount; i++){
			GameObject go = parent.GetChild(i).gameObject;
			go.SetActive (target == i);
		}
	}

	public void Update(){

		if (Input.GetKeyDown (KeyCode.Space)) {
			Bird.i.DropCoconut ();
		}
			
		if (Input.GetKeyDown (KeyCode.Escape)) {
			GameUI.i.TogglePausePanel ();
		}

	}

}
