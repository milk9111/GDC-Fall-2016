using UnityEngine;
using System.Collections;

public class WorkingBulletPattern : MonoBehaviour {

	public GameObject shot;
	public Transform shotSpawn;
	public BulletDetails bulletDetails;
	public bool halfMoon;
	private float shotAngle;
	private float halfsies;

	public void Start ()
	{
		float totalDegrees = 360;
		/*if (halfMoon) {
			totalDegrees = 180;
		}*/

		//shotAngle is used to space the bullets out evenly.
		if (bulletDetails.shotCount != 1 && bulletDetails.shotCount != 0) {
			shotAngle = (totalDegrees / bulletDetails.shotCount);
		} else {
			shotAngle = 180;
		}
		InvokeRepeating ("Fire", bulletDetails.delay, bulletDetails.fireRate);
	}

	public void Fire ()
	{
		float padding = 0;
		if (halfMoon && shotAngle < 90) {
			padding += 90 - shotAngle;
		}

		if (bulletDetails.shotCount % 2 != 1) {
			padding += shotAngle / 4;
		}

		float currentAngle = shotAngle + padding;

		Instantiate (shot, transform.position, Quaternion.Euler(0.0f, 180.0f, currentAngle));
		//Debug.Log ("first rotation: " + currentAngle);

		if (halfMoon) {
			halfsies = shotAngle / 2;
		}

		//This will instantiate the specified number of bullets at the specified directions
		for (int i = 1; i < bulletDetails.shotCount; i++) {
			if (halfMoon) {
				currentAngle = shotAngle + (halfsies * i) + padding;
			} else {
				currentAngle = (shotAngle * (i + 1)) + padding;
			}
			Instantiate(shot, transform.position, Quaternion.Euler(0.0f, 180.0f, currentAngle));
			//Debug.Log ("rotation: " + currentAngle);
			//Debug.Log ("clone instantiation rotation: " + clone.transform.rotation);
		}

	}
}
