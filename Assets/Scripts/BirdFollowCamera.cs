using UnityEngine;
using System.Collections;

public class BirdFollowCamera : MonoBehaviour
{

	public Bird bird;
	public float followRate = 0.9f;
	public float rotationRate = 0.8f;

	public Vector3 followDistance;

	public void LateUpdate ()
	{

		if (GameManager.i.paused || Bird.i.dead)
			return;
		

		Transform b = bird.transform;
		Vector3 target = b.position + bird.flattenedRotation * followDistance;
		transform.position = Vector3.Lerp (transform.position, target, followRate * 60.0f * Time.deltaTime);

		transform.rotation = Quaternion.Lerp (transform.rotation, bird.flattenedRotation, rotationRate * 60.0f * Time.deltaTime);

	}


}
