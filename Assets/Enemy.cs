using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Animator anim;

	// Use this for initialization
	void Start () {
		anim.SetFloat ("Speed", Random.value + 0.3f);
		transform.rotation = Quaternion.AngleAxis (Random.value * 360f, Vector3.up) * Quaternion.Euler(90f, 0, 0);
	}

}
