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

	public GameObject shot;
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
		//This will instantiate the specified number of bullets at the specified directions
		/*for (int i = 0; i < bulletDetails.shotCount; i++) {
			GameObject clone = Instantiate (shot, transform.position, 
				Quaternion.Euler(new Vector3 (0.0f, shotAngle * (i + 1) + halfsies, 0.0f))) as GameObject;
			Debug.Log ("rotation: " + shotAngle * (i + 1));
		}*/

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
