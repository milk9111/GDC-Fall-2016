using UnityEngine;
using System.Collections;

public class BulletSystem : MonoBehaviour {

	public GameObject bulletPattern;

	// Use this for initialization
	void Start () {
		Debug.Log ("bulletPattern instantiation position: " + transform.position);
		Instantiate (bulletPattern, transform.position, transform.rotation);
	}
}
