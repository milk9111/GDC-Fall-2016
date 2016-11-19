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

	void OnTriggerEnter2D (Collider2D other)
	{
		if (isBullet && (other.tag == "Boundary" || other.tag.Contains("Enemy"))) {
			return;
		}
		if (other.tag == "Boundary" || other.tag.Contains("Enemy"))
		{
			return;
		}
		Debug.Log (this.name);
		gameController.AddScore(scoreValue);

		if (explosion != null)
		{
			Instantiate (explosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}
		

		Destroy (other.gameObject);
		Destroy (gameObject);
		if (other.tag != "Player") {
			Done_GameController.totalHazards--;
		}
	}

}
