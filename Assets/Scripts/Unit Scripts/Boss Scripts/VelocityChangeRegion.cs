using UnityEngine;
using System.Collections;

public class VelocityChangeRegion : MonoBehaviour {
    public float multiplier = 1.5f;

    void OnTriggerEnter2D(Collider2D other) {
        Done_Mover oMover = other.GetComponent<Done_Mover>();
        if (oMover != null && other.gameObject.tag == "Bullet") {
            oMover.velocity *= multiplier;
        }
    }
}
