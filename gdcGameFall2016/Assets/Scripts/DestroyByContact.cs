using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {
    void OnTriggerEnter(Collider c)
    {
        if (c.tag != "Wall")
        {
            Destroy(c.gameObject);
            Destroy(gameObject);
        }
    }
}
