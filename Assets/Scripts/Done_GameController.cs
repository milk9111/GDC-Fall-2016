using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	[System.Serializable]
	public class Hazard
	{
		public GameObject enemy;
		public int enemyCount;
		public float spawnWait;
	}
	//both hazards and hazardsCount are parallel arrays. Hazards must be the same size as
	public Hazard[] hazards;

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
	public static int totalHazards;
	
	void Start ()
	{
		OnBegin ();
	}

	void OnBegin () {
		//Debug.Log ("Starting");
		totalHazards = 0;
		head = 0;
		for (int i = 0; i < hazards.Length; i++) {
			totalHazards += hazards[i].enemyCount;

            BulletCache.activeCache.addBulletToEnemyCache(hazards[i].enemy.GetComponent<PatternParent>().shot);
		}
		//Debug.Log ("totalHazards: " + totalHazards);
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
				OnBegin ();
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
			//Debug.Log("head: " + head);
			for (int i = 0; head < hazards.Length && i < hazards[head].enemyCount; i++)
			{
				GameObject hazard = hazards [head].enemy;
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                

                Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				if (!gameOver) {
					yield return new WaitForSeconds (hazards[head].spawnWait);
				}
			}

			if (!gameOver) {
				yield return new WaitForSeconds (Random.Range(1f, waveWait));
			}
				
			head++;
			//Debug.Log (hazards.Length + " " + head);

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
