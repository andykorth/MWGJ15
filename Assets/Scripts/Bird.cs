using UnityEngine;
using System.Collections;

public class Bird : SingletonScript<Bird> {

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

	private const float coconutDistance = 1.5f;

	public GameObject coconutFreeFallPrefab;

	private bool dead = false;

	public void Start(){
		coconut.localPosition = Vector3.down * coconutDistance;
	}

	private bool hasCoconut = true;


	public void DropCoconut(){

		if (!hasCoconut) {
			return;
		}

		hasCoconut = false;

		GameObject go = (GameObject) Instantiate (coconutFreeFallPrefab, coconut.position, Quaternion.identity);
		Rigidbody rb = go.GetComponent<Rigidbody> ();

//		rb.
//		rb.useGravity = false;
		rb.velocity = transform.forward * 80.0f;

		coconut.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider c){


		if (c.gameObject.layer == LayerMask.NameToLayer ("Ground")) {
			Vector3 bird = transform.position;
			Vector3 hitPoint = c.ClosestPointOnBounds (bird);

			Vector3 normal = bird - hitPoint;
			GameObject go = (GameObject) Instantiate (GameManager.i.birdDeadExplosion, bird, Quaternion.FromToRotation(-Vector3.forward, normal));
			Destroy (go, 2.0f);

			BirdDied ();
		} else {
			//Debug.Log ("Other collision");
		}
	}

	public void BirdDied(){
		Debug.Log ("Bird died");
		dead = true;

		this.gameObject.SetActive (false);

		GameManager.i.GameOver ();
	}

	public void AttachCoconut(){
		if (!hasCoconut) {
			hasCoconut = true;
			GameObject go = (GameObject) Instantiate (GameManager.i.gotACoconut, this.transform.position, Quaternion.identity);
			Destroy (go, 3.0f);
			go.transform.parent = this.transform;
			go.transform.localPosition = Vector3.zero;

			coconut.gameObject.SetActive (true);
		}
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
	
		if (dead)
			return;

		// updating position and velocity:
		Vector3 inputDir = new Vector3 (Input.GetAxisRaw ("Vertical") * turnSpeedY, Input.GetAxisRaw ("Horizontal") * turnSpeedX, 0);
		Vector3 thrust = this.transform.forward * speed;

		Debug.DrawLine (transform.position, transform.position + thrust, Color.red);

		Vector3 liftVec = vel.magnitude * lift * this.transform.up;
		vel = vel * drag + liftVec + thrust;

		// clamp vel from going straight up.
		float dot = Vector3.Dot(vel, Vector3.up);
		float d = Mathf.Pow (dot, 2.2f) / 1000.0f;
		if (float.IsNaN (d))
			d = 1.0f;
		d = Mathf.Max (1.0f, d);
		vel.y /= d;
//		Debug.Log ("dot: " + d);

		transform.position += (vel + Vector3.down * gravity) * Time.deltaTime;

		// Updating rotation of the bird:
		roll = Mathf.Lerp(roll, -Input.GetAxisRaw ("Horizontal") * rollMax, rollRate);
		coconutRoll = Mathf.Lerp (coconutRoll, roll, 0.02f);

		Debug.DrawLine (transform.position, transform.position + vel, Color.blue);

//		Debug.Log (rotation.eulerAngles.x);
		if (Mathf.Abs(rotation.eulerAngles.x - 270f) < 5.0f) {
			inputDir.x = 0f;
		}

		rotation = unrolledRotation * Quaternion.Euler (inputDir * Time.deltaTime) * Quaternion.AngleAxis (roll, Vector3.forward);

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

		coconut.localPosition =  Quaternion.AngleAxis (coconutRoll, transform.forward) * Vector3.up * -coconutDistance;

//		Debug.Log ("coconutRoll: " + coconutRoll);

		Debug.DrawLine (transform.position, coconut.position, Color.green);

	}
}
