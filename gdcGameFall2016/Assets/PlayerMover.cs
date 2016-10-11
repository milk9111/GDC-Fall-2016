using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {
    public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (horiz != 0) {
            transform.Translate(Vector3.right * speed * horiz * Time.deltaTime);
        }
        if (vert != 0) {
            transform.Translate(Vector3.up * speed * vert * Time.deltaTime);

        }
	}
}
