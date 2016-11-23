using UnityEngine;
using System.Collections;

public class RotatingPattern : PatternParent {  
    public Transform shotSpawn;
    public BulletDetails bulletDetails;
    public float tumbleSpeed;

    private int myBulletID = 0;

    public void Start() {
        //rb = shotSpawn.GetComponent<Rigidbody> ();
        //rb.angularVelocity = new Vector3 (0, 0, tumbleSpeed);
        InvokeRepeating("Fire", bulletDetails.delay, bulletDetails.fireRate);
        myBulletID = BulletCache.activeCache.getBulletID(shot);
    }

    public void Fire() {
        BulletCache.activeCache.getEnemyBullet(myBulletID, transform.position, shotSpawn.rotation);
        //Instantiate(shot, transform.position, shotSpawn.rotation);
    }

    void Update() {
        shotSpawn.Rotate(new Vector3(0.0f, 0.0f, tumbleSpeed * Time.deltaTime));
    }
}
