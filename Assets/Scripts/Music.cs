using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
    public AudioClip[] backgroundMusic; 
	private AudioSource source;
	int i =0;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.clip = backgroundMusic[i];

		source.Play ();


	}
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying) {
			i = (i+1)%backgroundMusic.Length;
			source.clip = backgroundMusic[i];
			source.Play ();

		}
	
	}
}
