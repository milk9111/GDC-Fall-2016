using UnityEngine;
using System.Collections;

public class RotatingPattern : MonoBehaviour {

    private Rigidbody rb;

    public GameObject shot;
    public Transform shotSpawn;
    public BulletDetails bulletDetails;
    public float tumbleSpeed;


    public void Start() {
        //rb = shotSpawn.GetComponent<Rigidbody> ();
        //rb.angularVelocity = new Vector3 (0, 0, tumbleSpeed);
        InvokeRepeating("Fire", bulletDetails.delay, bulletDetails.fireRate);
    }

    public void Fire() {
		Instantiate(shot, transform.position, shotSpawn.rotation);
    }

    void Update() {
        shotSpawn.Rotate(new Vector3(0.0f, 0.0f, tumbleSpeed * Time.deltaTime));
    }
}
