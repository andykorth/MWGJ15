using UnityEngine;
using System.Collections;

public class Frog : MonoBehaviour {

	public Animator anim;
	private float jumpCountdown = 0f;

	// Use this for initialization
	void Start () {
		jumpCountdown = Random.value * 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		jumpCountdown -= Time.deltaTime;
		if (jumpCountdown <= 0.0f) {
			jumpCountdown = Random.value * 6.0f + 3.0f;
			anim.SetTrigger ("LEAP");
		}
	}
}
