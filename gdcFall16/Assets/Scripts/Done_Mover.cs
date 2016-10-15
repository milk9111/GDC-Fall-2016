using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;

	//This is the default speed for the bullets. Bullet patterns for enemies 
	//will override this.
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
		//Debug.Log ("The velocity is: " + GetComponent<Rigidbody> ().velocity);
	}
}
