using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	private Vector3 vel;
	public float speed;

	public float lift = 0.2f;
	public float drag = 0.9f;
	public float turnSpeedX = 1.0f;
	public float turnSpeedY = 1.0f;
	public float rotationReturnRate = 0.1f;

	public float gravity = 1;

	public float rollRate = 0.3f;
	public float rollMax = 85.0f;
	private float roll = 0;

	public SphereCollider coconutCollider;

	private Quaternion rotation = Quaternion.identity;

	public Quaternion flattenedRotation {
		get{
			return Quaternion.Euler(new Vector3(0, rotation.eulerAngles.y, 0));
		}
	}

	public Quaternion unrolledRotation {
		get{
			return Quaternion.Euler(new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, 0));
		}
	}

	public void Start(){
		Physics.IgnoreCollision (this.GetComponent<SphereCollider> (), coconutCollider, true);
	}

	void Update () {
	
		Vector3 inputDir = new Vector3 (Input.GetAxisRaw ("Vertical") * turnSpeedY, Input.GetAxisRaw ("Horizontal") * turnSpeedX, 0);
		Vector3 thrust = this.transform.forward * speed;

		Debug.DrawLine (transform.position, transform.position + thrust, Color.red);

		Vector3 liftVec = vel.magnitude * lift * this.transform.up;
		vel = vel * drag + liftVec + thrust;

		transform.position += (vel + Vector3.down * gravity) * Time.deltaTime;

		roll = Mathf.Lerp(roll, -Input.GetAxisRaw ("Horizontal") * rollMax, rollRate);

		Debug.DrawLine (transform.position, transform.position + vel, Color.blue);

		Vector3 euler = rotation.eulerAngles;


		rotation = unrolledRotation * Quaternion.Euler (inputDir * Time.deltaTime) * Quaternion.AngleAxis (roll, Vector3.forward);

//		rotation *= Quaternion.Euler (inputDir * Time.deltaTime);
//
//		rotation = Quaternion.Euler(new Vector3(euler.x + inputDir.x * Time.deltaTime, rotation.eulerAngles.y +inputDir.z * Time.deltaTime, roll));


		rotation = Util.ConstantSlerp (rotation, flattenedRotation, rotationReturnRate * Time.deltaTime);
		transform.localRotation = rotation;

	}
}
