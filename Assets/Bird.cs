using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	private Vector3 vel;
	public float speed;

	public float lift = 0.2f;
	public float drag = 0.9f;

	public Rigidbody rb;

	// Update is called once per frame
	void Update () {
	
		Vector2 inputDir = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		Quaternion q = this.transform.rotation;
		Vector3 turning = q * inputDir;
		Vector3 thrust = this.transform.forward * speed + turning;

		Debug.DrawLine (transform.position, transform.position + thrust, Color.red);

//		rb.AddForce (inputDir * Time.deltaTime);

		Vector3 liftVec = rb.velocity.magnitude * lift * this.transform.up;
		rb.velocity = rb.velocity * drag + liftVec + thrust * Time.deltaTime;

	}
}
