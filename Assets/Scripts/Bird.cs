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

	public void DropCoconut(){
		GameObject go = (GameObject) Instantiate (coconutFreeFallPrefab, coconut.position, Quaternion.identity);
		go.GetComponent<Rigidbody> ().velocity = vel;

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
			Debug.Log ("Other collision");
		}
	}

	public void BirdDied(){
		Debug.Log ("Bird died");
		dead = true;

		this.gameObject.SetActive (false);

		GameManager.i.GameOver ();
	}

	public void AttachCoconut(){
		coconut.gameObject.SetActive (true);
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

		Vector3 inputDir = new Vector3 (Input.GetAxisRaw ("Vertical") * turnSpeedY, Input.GetAxisRaw ("Horizontal") * turnSpeedX, 0);
		Vector3 thrust = this.transform.forward * speed;

		Debug.DrawLine (transform.position, transform.position + thrust, Color.red);

		Vector3 liftVec = vel.magnitude * lift * this.transform.up;
		vel = vel * drag + liftVec + thrust;

		transform.position += (vel + Vector3.down * gravity) * Time.deltaTime;

		roll = Mathf.Lerp(roll, -Input.GetAxisRaw ("Horizontal") * rollMax, rollRate);
		coconutRoll = Mathf.Lerp (coconutRoll, roll, 0.02f);

		Debug.DrawLine (transform.position, transform.position + vel, Color.blue);

		rotation = unrolledRotation * Quaternion.Euler (inputDir * Time.deltaTime) * Quaternion.AngleAxis (roll, Vector3.forward);

		rotation = Util.ConstantSlerp (rotation, flattenedRotation, rotationReturnRate * Time.deltaTime);
		transform.localRotation = rotation;

		UpdateCoconut ();

		if (Input.GetKeyDown (KeyCode.Space)) {
			DropCoconut ();
		}

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
