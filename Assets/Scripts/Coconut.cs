using UnityEngine;
using System.Collections;

public class Coconut : MonoBehaviour {

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			
			foreach (ContactPoint contact in collision.contacts) {

				GameObject go = (GameObject) Instantiate (GameManager.i.coconutLandingExplosion, contact.point,Quaternion.FromToRotation(Vector3.forward, contact.normal));
				Destroy (go, 2.0f);
			}
			Destroy (this.gameObject);
		}
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer ("Nest")) {

			foreach (ContactPoint contact in collision.contacts) {

				GameObject go = (GameObject) Instantiate (GameManager.i.coconutSuccess, contact.point,Quaternion.FromToRotation(Vector3.forward, contact.normal));
				Destroy (go, 2.0f);

				GameManager.i.GetPoint ();
			}
			Destroy (this.gameObject);
		}

	}
}
