using UnityEngine;
using System.Collections;

public class RotateSlowly : MonoBehaviour {

	public float speed;
	public float distance = 8f;

	public Transform target;

	public void Update(){
		float d = distance + Mathf.Sin (Time.time* 2.0f);
		this.transform.position = new Vector3 (Mathf.Sin (Time.time * speed) * d, 0f, Mathf.Cos (Time.time * speed) * d);
		this.transform.LookAt (target.position);
	}

}
