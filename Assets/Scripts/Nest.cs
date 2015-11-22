using UnityEngine;
using System.Collections;

public class Nest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SphereCollider sc = this.GetComponent<SphereCollider> ();
		foreach (SphereCollider c in Bird.i.GetComponentsInChildren<SphereCollider>()) {
			Physics.IgnoreCollision (c, sc);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
