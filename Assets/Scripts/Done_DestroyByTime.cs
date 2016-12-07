using UnityEngine;
using System.Collections;

public class Done_DestroyByTime : MonoBehaviour
{
	public float lifetime;
    private float deathTime = 0;

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
        
		//Destroy (gameObject, lifetime);
	}

	void Update () {
        deathTime += Time.deltaTime;
        if (deathTime >= lifetime) {
            BulletCache.activeCache.requeueBullet(gameObject);
			deathTime = 0;
        }
		if (gameObject == null) {
			Done_GameController.totalHazards--;
		}
	}
}
