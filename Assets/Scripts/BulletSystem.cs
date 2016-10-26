using UnityEngine;
using System.Collections;

public class BulletSystem : MonoBehaviour {	

	public GameObject shot;
	public Transform shotSpawn;
	public BulletDetails details;
	public string patternType;
	private Pattern pattern;

	// Use this for initialization
	void Start () {
		Debug.Log ("in BulletSystem start");
		/*switch (patternType) {
		case "C": 
			Debug.Log ("in C case");
				CirclePattern pattern = new CirclePattern (shot, shotSpawn, details, true);
				break;
			default:
				break;
		}*/
		pattern = new CirclePattern (shot, shotSpawn, details, true);
		Debug.Log ("about to start coroutine");
		StartCoroutine (StartFire ());
	}

	IEnumerator StartFire () {
		Debug.Log ("inside coroutine");
		while (true) {
			Debug.Log ("inside coroutine loop");
			Debug.Log (pattern);
			pattern.Fire ();
			Debug.Log ("fired a shot");
			yield return new WaitForSeconds (details.delay);
		}
	}
}
