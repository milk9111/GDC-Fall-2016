using UnityEngine;
using System.Collections;

//This class is also temporary. It is just here for organization.
[System.Serializable]
public class BulletDetails {
	public float fireRate, delay;
	public int shotCount;
}

public class BulletPattern : MonoBehaviour, Pattern {

	//These will be changed to private as this bullet pattern
	//will be instantiated by a later bullet system that
	//will be applied to all enemies.

	public GameObject shot;
	public Transform shotSpawn;
	public BulletDetails bulletDetails;

	public BulletPattern (GameObject theShot, Transform theShotSpawn, BulletDetails theBulletDetails)
	{
		Debug.Log ("created BulletPattern");
		shot = theShot;
		shotSpawn = theShotSpawn;
		bulletDetails = theBulletDetails;
		InvokeRepeating ("Fire", bulletDetails.delay, bulletDetails.fireRate);
	}

	public void Fire () {		
		Debug.Log ("in BulletPattern fire");
		Instantiate (shot, shotSpawn);
	}

	public Transform GetShotSpawn () {
		return shotSpawn;
	}

	public BulletDetails GetDetails () {
		return bulletDetails;
	}
}
