using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	public bool isBullet;
	private Done_GameController gameController;


	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

    void OnTriggerEnter2D(Collider2D other) {
        if (isBullet && (other.tag == "Boundary" || other.tag.Contains("Enemy"))) {
            return;
        }
        if (other.tag == "Boundary" || other.tag.Contains("Enemy")) {
            return;
        }
        Debug.Log(this.name);
        gameController.AddScore(scoreValue);

        if (explosion != null) {
            Instantiate(explosion, transform.position, transform.rotation);
        }

        if (other.tag == "Player") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        // If we're an enemy and the other gameObject is a bullet, requeue it.
        if (!isBullet && other.gameObject.tag == "Bullet") {
            BulletCache.activeCache.requeueBullet(other.gameObject, true);
        // If we're an enemy and the other isn't a bullet, just destroy it.
        } else if (!isBullet) {
            Destroy(other.gameObject);
        // If we're a bullet, requeue us.
        } else if (isBullet) {
            BulletCache.activeCache.requeueBullet(gameObject);
        // Otherwise, destroy us.
        } else {
            Destroy(gameObject);
        }

        if (other.tag != "Player") {
			Done_GameController.totalHazards--;
		}
	}

}
