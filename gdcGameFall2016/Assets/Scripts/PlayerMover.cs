using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMover : MonoBehaviour {
    
    public float speed, tilt, fireRate;
    public Boundary bounds;

    public GameObject bullet;
    public Transform shotSpawn;

    private Rigidbody rb;
    private float nextFire;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }

    // Use FixedUpdate for physics
    void FixedUpdate ()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horiz * speed, 0.0f, vert * speed);
        rb.position = new Vector3(Mathf.Clamp (rb.position.x, bounds.xMin, bounds.xMax), 0.0f, 
            Mathf.Clamp(rb.position.z, bounds.zMin, bounds.zMax));

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    void Update ()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }
    }
	
	// Update is called once per frame
	/*void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (horiz != 0) {
            transform.Translate(Vector3.right * speed * horiz * Time.deltaTime);
        }
        if (vert != 0) {
            transform.Translate(Vector3.up * speed * vert * Time.deltaTime);

        }
	}*/
}
