using UnityEngine;
using System.Collections;

public interface Pattern {
	
	void Fire ();

	Transform GetShotSpawn ();

	BulletDetails GetDetails ();
}
