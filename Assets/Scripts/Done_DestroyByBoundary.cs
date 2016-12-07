using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	private Done_GameController gameController;

	void Start () {
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

	void OnTriggerExit2D (Collider2D other) 
	{
		if (other.tag != "BulletEnemy" && other.tag.Contains("Enemy")) {
			Done_GameController.totalHazards--;
		}

		if (other.tag != "BulletEnemy" && other.tag != "Bullet") {
			Destroy (other.gameObject);
		} else {
			BulletCache.activeCache.requeueBullet(other.gameObject);
		}
	}
}