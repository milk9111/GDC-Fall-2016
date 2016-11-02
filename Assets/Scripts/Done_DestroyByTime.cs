using UnityEngine;
using System.Collections;

public class Done_DestroyByTime : MonoBehaviour
{
	public float lifetime;

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

		Destroy (gameObject, lifetime);
	}

	void Update () {
		if (gameObject == null) {
			gameController.totalHazards--;
			Debug.Log ("DestroyByTime totalHazards: " + gameController.totalHazards);
		}
	}
}
