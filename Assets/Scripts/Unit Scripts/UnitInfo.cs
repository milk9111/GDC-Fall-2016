using UnityEngine;
using System.Collections;

public class UnitInfo : MonoBehaviour {
	
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

			if ((this.tag == "Player" || this.tag == "Ally") && other.tag == "BulletEnemy") {

				damageHandlerBullet(other);

			} else if (this.tag == "Enemy" && other.tag == "Bullet") {

				damageHandlerBullet(other);

				showHealth();

			} else if ((this.tag == "Player" || this.tag == "Ally") && other.tag == "Enemy") {
			
				damageHandlerUnit(other);
			
			} else if (this.tag == "Enemy" && (other.tag == "Player" || other.tag == "Ally")) {

				damageHandlerUnit(other);

				showHealth();
				
			} else if (this.tag == "Player" && other.tag == "Potion") {
			
				if (currentHealth + other.gameObject.GetComponent<UnitInfo>().getDamage() <= maxHealth)
					currentHealth += other.gameObject.GetComponent<UnitInfo>().getDamage();
				
			else
				currentHealth = maxHealth;
			
			}

			if (currentHealth <= 0) {
				Destroy(this.gameObject);
			}
		}
	}

	void damageHandlerBullet(Collider2D other) {

		if (other.gameObject.GetComponent<Damage>().getDamage() >= 0)
			currentHealth -= other.gameObject.GetComponent<Damage>().getDamage();

		// The gameObject will be destroyed if an enemy has negative damage.
		else
			currentHealth = 0;

		Destroy(other);
	}

	void damageHandlerUnit(Collider2D other) {

		if (other.gameObject.GetComponent<UnitInfo>().getDamage() >= 0)
			currentHealth -= other.gameObject.GetComponent<UnitInfo>().getDamage();

		// The gameObject will be destroyed if an enemy has negative damage.
		else
			currentHealth = 0;
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

	/*
	public void OnDestroy() {
		GameObject.Find("UI Overlay").GetComponent<ScoreTracker>().increaseScore(points);
		//Instantiate Explosion or something
	}
	*/
}