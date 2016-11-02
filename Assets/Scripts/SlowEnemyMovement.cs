using UnityEngine;
using System.Collections;

public class SlowEnemyMovement : MonoBehaviour {

	public Done_Boundary boundary;
	public float tilt;
	private float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	private Done_Mover ourMover;

	void Start ()
	{
		dodge = Random.Range (0.5f, 1f);
		ourMover = GetComponent<Done_Mover>();
		StartCoroutine(Evade());
	}

	IEnumerator Evade ()
	{
		targetManeuver = dodge * -Mathf.Sign (transform.position.x);
		//yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true)
		{
			if (boundary.xMax - transform.position.x <= 3 || transform.position.x - boundary.xMin <= 3) {
				targetManeuver = dodge * -Mathf.Sign (transform.position.x);
			}
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	void FixedUpdate ()
	{
		currentSpeed = ourMover.velocity.y;
		float newManeuver = Mathf.MoveTowards (ourMover.velocity.x, targetManeuver, smoothing * Time.deltaTime);

		ourMover.velocity = new Vector3 (newManeuver, currentSpeed, 0.0f);

		transform.position = new Vector3
			(
				Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
				0.0f
			);


		//GetComponent<Rigidbody>().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody>().velocity.x * -tilt);
	}
}
