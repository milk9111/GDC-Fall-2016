 using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, yMin, yMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;

	public GameObject playerModel;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	 
	private float nextFire;

    /*private int testInt;

    void Start() {
        testInt = 1;
    }*/
    

	void Update ()
	{

		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire1") && Time.time > nextFire) && Time.timeScale != 0.0f) 
        {
            nextFire = Time.time + fireRate;
            //Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

			//On this line we need to be able to change 0 in order to get the correct bullet for 
			//the player depending on the current ability used. Changing it to 1 for now to test
			//the mage bullet sprite.
            BulletCache.activeCache.getPlayerBullet(1, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        
        transform.Translate(movement * speed * Time.deltaTime);
        
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );

        //testInt++;
        //Disabling rotation of the rigid body for the moment, this will need to be done by rotating the model now.
		//playerModel.transform.rotation = Quaternion.Euler (GetComponent<Rigidbody2D>().velocity.y * -tilt, 0.0f, 0.0f);
    }
}
