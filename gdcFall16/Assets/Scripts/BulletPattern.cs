using UnityEngine;
using System.Collections;

//This class is also temporary. It is just here for organization.
[System.Serializable]
public class BulletDetails {
	public float fireRate, delay, bulletSpeed;
	public int shotCount;
}

public class BulletPattern : MonoBehaviour {

	//These will be changed to private as this bullet pattern
	//will be instantiated by a later bullet system that
	//will be applied to all enemies.

	public Rigidbody shot;
	public Transform shotSpawn;
	public BulletDetails bulletDetails;

	//This isn't in BulletDetails because it can't be calculated by 
	//an uninitialized shotCount field so it has be done here.
	private float shotAngle;

	void Start ()
	{
		//shotAngle is used to space the bullets out evenly. Will
		//be updated if we want non-circular firing abilities.
		shotAngle = 360 / bulletDetails.shotCount;
		InvokeRepeating ("Fire", bulletDetails.delay, bulletDetails.fireRate);
	}

	void Fire ()
	{
		//This will instantiate the specified number of bullets at the specified directions
		for (int i = 0; i < bulletDetails.shotCount; i++) {
			GameObject clone = Instantiate (shot, shotSpawn.position, 
				Quaternion.Euler(new Vector3 (0.0f, shotAngle * (i + 1), 0.0f))) as GameObject;
			Rigidbody temp = clone.GetComponent<Rigidbody> ();
			temp.velocity = transform.TransformDirection(transform.forward * bulletDetails.bulletSpeed);
		}
	}
}
