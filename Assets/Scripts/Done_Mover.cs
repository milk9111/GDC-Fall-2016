using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
    public Vector2 velocity;

	//This is the default speed for the bullets and enemies. Bullet patterns for enemies 
	//will override this.
	void Start () {
        changeSpeed(speed);
	}

    public void changeSpeed(float newSpeed) {
        speed = newSpeed;
        velocity.x = Mathf.Sin(transform.eulerAngles.y * (Mathf.PI / 180)) * speed;
        velocity.y = Mathf.Cos(transform.eulerAngles.y * (Mathf.PI / 180)) * speed;
    }

    void Update() {
        //Debug.Log("Pre: Velocity: " + velocity.ToString() + " Pos: " + transform.position.ToString());
        transform.Translate(velocity * Time.deltaTime);
        //Debug.Log("Post: Velocity: " + velocity.ToString() + " Pos: " + transform.position.ToString());
    }
}
