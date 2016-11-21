using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
    public AudioClip[] backgroundMusic; 
	public AudioListener listener;

	private AudioSource source;
	int i =0;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		source.clip = backgroundMusic[i];

		source.Play ();
		listener.enabled = true;


	}
	// Update is called once per frame
	void Update () {
		if (!source.isPlaying) {
			i = (i+1)%backgroundMusic.Length;
			source.clip = backgroundMusic[i];
			source.Play ();

		}
	
	}

	public void Mute () {
		listener.enabled = !listener.enabled;
		if (listener.enabled) {
			source.Play ();
		}
	}
}
