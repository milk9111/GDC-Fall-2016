using UnityEngine;
using System.Collections;

public class UnitInfo : MonoBehaviour {

	public GameObject explosion;
	public GameObject gameOverlay;
	//public Texture damaged;

	public long maxHealth;
	protected long currentHealth;
	public long damage;

	public bool DISPLAY_HEALTH = true;
	public bool invulnerable = false;

	public int points;

	void Awake() {

		currentHealth = maxHealth;

	}

	void OnTriggerEnter2D(Collider2D other) {
		// This goes through the gameObject to get the Damage script.
		if ( !invulnerable ) {

			//Enemy bullet hit player
			if (this.tag == "Player"&& other.tag == "BulletEnemy") {
				Debug.Log ("enemy bullet hit player");

				damageHandlerBullet(other);

			//Player bullet hit enemy
			} else if (this.tag == "Enemy" && other.tag == "Bullet") {

				damageHandlerBullet(other);

				showHealth();

			//Player hit enemy
			} else if (this.tag == "Player" && other.tag == "Enemy") {

				damageHandlerUnit(other);

			//Enemy hit player
			} else if (this.tag == "Enemy" && other.tag == "Player") {

				damageHandlerUnit(other);
				if (!this.tag.Equals ("Player")) {
					showHealth ();
				}


			} else if (this.tag == "Player" && other.tag == "Potion") {

				if (currentHealth + other.gameObject.GetComponent<UnitInfo>().getDamage() <= maxHealth)
					currentHealth += other.gameObject.GetComponent<UnitInfo>().getDamage();

				else
					currentHealth = maxHealth;

			}

			if (currentHealth <= 0) {

				GameObject.Find("Game Overlay").GetComponent<ScoreTracker>().increaseScore(points);
				if (explosion != null) {
					Debug.Log ("Made explosion");
					Instantiate(explosion, transform.position, transform.rotation);
				}
					
				//Destroy (other.gameObject);
				Destroy(this.gameObject);
			}
		}
	}

	void damageHandlerBullet(Collider2D other) {

		// If we're an enemy and the other gameObject is a bullet, requeue it.
		if (other.gameObject.tag == "Bullet") {
			Debug.Log ("Requeued player bullet");
			BulletCache.activeCache.requeueBullet(other.gameObject, true);
		} else {
			Debug.Log ("Requeued enemy bullet");
			BulletCache.activeCache.requeueBullet(other.gameObject);
		} 

		if (other.gameObject.GetComponent<Damage> ().getDamage () >= 0) {
			currentHealth -= other.gameObject.GetComponent<Damage> ().getDamage ();

		// The gameObject will be destroyed if an enemy has negative damage.
		} else {
			currentHealth = 0;
		}

		//Debug.Log (other.name);
		//Destroy(other);
	}

	void damageHandlerUnit(Collider2D other) {

		if (other.gameObject.GetComponent<UnitInfo> ().getDamage () >= 0) {
			currentHealth -= other.gameObject.GetComponent<UnitInfo> ().getDamage ();
			//StartCoroutine(changeColor2 (other));
		}

		// The gameObject will be destroyed if an enemy has negative damage.
		else {
			currentHealth = 0;
		}
	}

	void changeColor (Collider2D other) {
		Color temp = other.gameObject.GetComponent<Material> ().GetColor ("_MainTex");
		other.gameObject.GetComponent<Material> ().SetColor ("_MainTex", Color.white);
		//yield return new WaitForSeconds (0.5f);
		other.gameObject.GetComponent<Material> ().SetColor ("_MainTex", temp);

	}

	IEnumerator changeColor2 (Collider2D other) {
		Color temp = other.gameObject.GetComponent<Material> ().GetColor ("_MainTex");
		other.gameObject.GetComponent<Material> ().SetColor ("_MainTex", Color.white);
		yield return new WaitForSeconds (0.5f);
		other.gameObject.GetComponent<Material> ().SetColor ("_MainTex", temp);

	}

	void showHealth() {

		if (DISPLAY_HEALTH)
			GameObject.Find("Game Overlay").GetComponent<EnemyHealthBar>().setCurrentUnit(this.gameObject);
	}

	public long getMaxHealth() {
		return maxHealth;
	}

	public long getCurrentHealth() {
		return currentHealth;
	}

	public long getDamage() {
		return damage;
	}

	public bool isDisplayHealth() {
		return DISPLAY_HEALTH;
	}
}