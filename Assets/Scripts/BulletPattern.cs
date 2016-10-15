using UnityEngine;
using System.Collections;

//This class is also temporary. It is just here for organization.
[System.Serializable]
public class BulletDetails {
	public float fireRate, delay;
	public int shotCount;
}

public class BulletPattern : MonoBehaviour {

	//These will be changed to private as this bullet pattern
	//will be instantiated by a later bullet system that
	//will be applied to all enemies.

	public Rigidbody shot;
	public Transform shotSpawn;
	public bool halfMoon;
	public BulletDetails bulletDetails;

	//This isn't in BulletDetails because it can't be calculated by 
	//an uninitialized shotCount field so it has be done here.
	private float shotAngle;

	//This will be 0 by default, but if halfMoon is chosen for shape,
	//halfsies will be set to the constant 78 degrees in order to make 
	//a front arc.
	private float halfsies;

	void Start ()
	{
		float totalDegrees = 360;
		if (halfMoon) {
			totalDegrees = 180;
			halfsies = 68 + bulletDetails.shotCount;
		}

		//shotAngle is used to space the bullets out evenly.
		if (bulletDetails.shotCount != 1) {
			shotAngle = (totalDegrees / bulletDetails.shotCount) % totalDegrees;
		} else {
			shotAngle = 180;
		}
		InvokeRepeating ("Fire", bulletDetails.delay, bulletDetails.fireRate);
	}

	void Fire ()
	{
		//This will instantiate the specified number of bullets at the specified directions
		for (int i = 0; i < bulletDetails.shotCount; i++) {
			Instantiate (shot, shotSpawn.position, 
				Quaternion.Euler(new Vector3 (0.0f, shotAngle * (i + 1) + halfsies, 0.0f)));
		}
	}
}
