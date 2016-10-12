using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

    void OnTriggerExit(Collider c)
    {
        Destroy(c.gameObject);
    }
}
