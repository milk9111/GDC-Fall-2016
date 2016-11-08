using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	//both hazards and hazardsCount are parallel arrays. Hazards must be the same size as
	public GameObject[] hazards;
	public int[] hazardsCount;
	public float[] spawnWaits;

	public Vector3 spawnValues;
	//public int hazardCount;
	//public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	
	private bool gameOver;
	private bool restart;
	private int score;
	private int head;
	public int totalHazards;
	
	void Start ()
	{
		for (int i = 0; i < hazardsCount.Length; i++) {
			totalHazards += hazardsCount [i];
		}
		Debug.Log (totalHazards);
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}

	void OnBegin () {
		
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}

			for (int i = 0; i < hazardsCount[head] && head < hazardsCount.Length; i++)
			{
				GameObject hazard = hazards [head];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                //Debug.Log(spawnPosition);

                Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				if (!gameOver) {
					yield return new WaitForSeconds (spawnWaits[head]);
				}
			}

			if (!gameOver) {
				yield return new WaitForSeconds (Random.Range(1f, waveWait));
			}
			head++;
			Debug.Log (hazardsCount.Length + " " + head);

			if (totalHazards <= 0 && !gameOver) {
				WinGame ();
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void WinGame () {
		gameOverText.text = "Level Complete";
		gameOver = true;
	}
}
