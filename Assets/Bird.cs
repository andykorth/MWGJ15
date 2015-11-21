using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	private Vector3 vel;
	public float speed;

	public float lift = 0.2f;
	public float drag = 0.9f;
	public float turnSpeed = 1.0f;
	public float rotationReturnRate = 0.1f;

	public Rigidbody rb;


	void FixedUpdate () {
	
		Vector2 inputDir = new Vector2 (Input.GetAxisRaw ("Vertical"), Input.GetAxisRaw ("Horizontal"));

//		Quaternion q = this.transform.rotation;
//		Vector3 turning = q * inputDir;
		Vector3 thrust = this.transform.forward * speed;

		Debug.DrawLine (transform.position, transform.position + thrust, Color.red);

//		rb.AddForce (inputDir * Time.deltaTime);

		Vector3 liftVec = rb.velocity.magnitude * lift * this.transform.up;
		rb.velocity = rb.velocity * drag + liftVec + thrust * Time.deltaTime;

		transform.localRotation *= Quaternion.Euler (inputDir * Time.deltaTime * turnSpeed);

		Quaternion flat = Quaternion.Euler(new Vector3(0, transform.localRotation.eulerAngles.y, 0));
		transform.localRotation = Util.ConstantSlerp (transform.localRotation, flat, rotationReturnRate * Time.deltaTime);
	}
}
