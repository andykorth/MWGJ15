using UnityEngine;
using System.Collections;

public class CoconutRing : MonoBehaviour {

	void OnTriggerEnter(Collider c){
		
		if (c.gameObject.layer == LayerMask.NameToLayer ("Bird")) {
			Debug.Log ("Got a coconut!");
			Bird.i.AttachCoconut ();

		}

	}
}
