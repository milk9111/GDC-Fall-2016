using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VelocityChangeRegion : MonoBehaviour {
    private HashSet<Transform> ourMovers;

    public float newSpeed;
    public float changeRate;

    void Start() {
        ourMovers = new HashSet<Transform>();
    }

    void Update() {
        foreach (Transform bullet in ourMovers) {
            Done_Mover oMover = bullet.GetComponent<Done_Mover>();
            float currentSpeed = oMover.speed;
            float sign = Mathf.Sign(newSpeed - currentSpeed);
            float changedSpeed = currentSpeed + (sign * changeRate * Time.deltaTime);
            if (Mathf.Abs(newSpeed - currentSpeed) < Mathf.Abs(newSpeed - changedSpeed)) {
                changedSpeed = newSpeed;
            }
            oMover.changeSpeed(changedSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        Done_Mover oMover = other.GetComponent<Done_Mover>();
        if (oMover != null && other.gameObject.tag == "BulletEnemy") {
            ourMovers.Add(other.transform);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        Done_Mover oMover = other.GetComponent<Done_Mover>();
        if (oMover != null && other.gameObject.tag == "BulletEnemy") {
            ourMovers.Remove(other.transform);
        }
    }
}
