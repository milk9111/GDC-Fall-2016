using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour {

	public Text scoreText;
	private int score = 0;

	void Start() {
		scoreText.text = ("Score: "+ score);
	}


	public void increaseScore(int points) {
		score += points;
		scoreText.text = ("Score: "+ score);
	}
}
