using UnityEngine;
using System.Collections;

public class BulletSystem : MonoBehaviour {	

	public GameObject bulletPattern;
	public Transform spawn;
	public string patternType;

	private BulletPattern pattern;

	// Use this for initialization
	void Start () {
		pattern = bulletPattern.GetComponent<BulletPattern> ();
		/*switch (patternType) {
		case "C": 
			Debug.Log ("in C case");
				CirclePattern pattern = new CirclePattern (shot, shotSpawn, details, true);
				break;
			default:
				break;
		}*/
		Debug.Log (patternType.Equals("C"));
		if (patternType.Equals ("C")) {
			pattern = Instantiate (bulletPattern, spawn) as CirclePattern;
		} else {
			pattern = Instantiate (bulletPattern, spawn) as BulletPattern;
		}
		//StartCoroutine (StartFire ());
	}

	IEnumerator StartFire () {
		Debug.Log ("inside coroutine");
		while (true) {
			Debug.Log ("inside coroutine loop");
			Debug.Log (pattern);
			pattern.Invoke ("Fire", pattern.GetDetails ().delay);
			Debug.Log ("fired a shot");
			yield return new WaitForSeconds (pattern.GetDetails().delay);
		}
	}
}
