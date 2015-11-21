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

	private float coconutRoll = 0;

	public Transform coconut;

	private Quaternion rotation = Quaternion.identity;

	public void Start(){
		coconut.localPosition = Vector3.down * 1.5f;
	}

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

	void Update () {
	
		Vector3 inputDir = new Vector3 (Input.GetAxisRaw ("Vertical") * turnSpeedY, Input.GetAxisRaw ("Horizontal") * turnSpeedX, 0);
		Vector3 thrust = this.transform.forward * speed;

		Debug.DrawLine (transform.position, transform.position + thrust, Color.red);

		Vector3 liftVec = vel.magnitude * lift * this.transform.up;
		vel = vel * drag + liftVec + thrust;

		transform.position += (vel + Vector3.down * gravity) * Time.deltaTime;

		roll = Mathf.Lerp(roll, -Input.GetAxisRaw ("Horizontal") * rollMax, rollRate);
		coconutRoll = Mathf.Lerp (coconutRoll, roll, 0.02f);

		Debug.DrawLine (transform.position, transform.position + vel, Color.blue);

		Vector3 euler = rotation.eulerAngles;


		rotation = unrolledRotation * Quaternion.Euler (inputDir * Time.deltaTime) * Quaternion.AngleAxis (roll, Vector3.forward);

//		rotation *= Quaternion.Euler (inputDir * Time.deltaTime);
//
//		rotation = Quaternion.Euler(new Vector3(euler.x + inputDir.x * Time.deltaTime, rotation.eulerAngles.y +inputDir.z * Time.deltaTime, roll));

		//kinematic.velocity = vel;

		rotation = Util.ConstantSlerp (rotation, flattenedRotation, rotationReturnRate * Time.deltaTime);
		transform.localRotation = rotation;

		UpdateCoconut ();
	}

//	private Vector3 coconutRelativeVelocity;

	public void UpdateCoconut(){
//		Vector3 coconutRelativeVelocity = Vector3.down * gravity;
//		Debug.DrawLine (coconut.position, coconut.position + coconutRelativeVelocity, Color.green);
//
//
//		Vector3 pos = Vector3.Lerp(coconut.localPosition, coconutRelativeVelocity * Time.deltaTime, 0.2f);
//		pos = Vector3.ClampMagnitude (pos, 3f);

		coconut.localPosition =  Quaternion.AngleAxis (coconutRoll, transform.forward) * Vector3.up * -1.5f;

//		Debug.Log ("coconutRoll: " + coconutRoll);

		Debug.DrawLine (transform.position, coconut.position, Color.green);

	}
}
