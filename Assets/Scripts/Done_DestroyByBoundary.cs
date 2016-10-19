using UnityEngine;
using System.Collections;

public class Done_DestroyByBoundary : MonoBehaviour
{
	void OnTriggerExit2D (Collider2D other) 
	{
		Destroy(other.gameObject);
	}
}