using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float rotateSpeed;
	public GameObject quad;
	
	// Update is called once per frame
	void Update () {
		quad.transform.Rotate(new Vector3(0.0f, 0.0f, rotateSpeed * Time.deltaTime));
	}
}
