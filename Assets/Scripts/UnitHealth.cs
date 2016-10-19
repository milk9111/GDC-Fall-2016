using UnityEngine;
using System.Collections;

public class UnitHealth : MonoBehaviour {
	
	public long maxHealth;
	public long currentHealth;
	
	public bool DISPLAY_HEALTH = true;
	
	void Start() {

		currentHealth = maxHealth;
		Debug.Log("Max Health: "+ maxHealth);
		Debug.Log("Current Health: "+ currentHealth);
		
		if (DISPLAY_HEALTH) {
			Debug.Log("Health Bar");
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		// This goes through the gameObject to get the Damage script.
		
		if ( ((this.tag == "Player" || this.tag == "Ally" ) && other.tag == "Enemy") || (this.tag == "Enemy" && (other.tag == "Ally")) ) {
			
			if (other.gameObject.GetComponent<Damage>().getDamage() >= 0)
				this.currentHealth -= other.gameObject.GetComponent<Damage>().getDamage();
			// The gameObject will be destroyed if an enemy has negative damage.
			else
				this.currentHealth = 0;
			
			Debug.Log ("Current Health: " + currentHealth);
		}
		else if (other.tag == "Potion") {
			
			if (this.currentHealth + other.gameObject.GetComponent<Damage>().getDamage() <= this.maxHealth)
				this.currentHealth += other.gameObject.GetComponent<Damage>().getDamage();
			else
				this.currentHealth = this.maxHealth;
			
			Debug.Log ("Current Health: " + currentHealth);
		}
	}
	
	// Update is called once per frame
	void Update() {
		
		if (currentHealth <= 0) {
			Destroy(this.gameObject);
		}
	}
	
	long getMaxHealth() {
		return maxHealth;
	}
	
	long getCurrentHealth() {
		return currentHealth;
	}
}
