using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour {

	public Image health;
	public Text healthFraction;
	private long maxHealth;
	private long currentHealth;

	void Awake() {

		//health.Instantiate(HealthBarImage) as GameObject;
		maxHealth = GameObject.Find("Encapsulated_Player").GetComponent<UnitInfo>().getMaxHealth();
		health.fillAmount = 1.0f;

		healthFraction.text = (currentHealth +"/"+ maxHealth);
	}

	void FixedUpdate() {

		// An if-else block to handle the player objects destruction.
		if (GameObject.Find("Encapsulated_Player") != null) {

			currentHealth = GameObject.Find("Encapsulated_Player").GetComponent<UnitInfo>().getCurrentHealth();
			health.fillAmount = (float)currentHealth / (float)maxHealth;

			healthFraction.text = (currentHealth +"/"+ maxHealth);

		} else {
			health.fillAmount = 0.0f;

			healthFraction.text = "";
		}
	}
}

/*

Image {
	
	For the general Image API go to: <https://docs.unity3d.com/ScriptReference/UI.Image.html>.
	
	For the Image.fillAmount API go to: <https://docs.unity3d.com/ScriptReference/UI.Image-fillAmount.html>.
		May also want to use Image.fillOrigin.
	
	See the Image.type for information.
		The type to most likely be used is Filled.
	
	See Image.sprite for information.
	
}

Canvas {
	
	For the general Canvas API go to: <https://docs.unity3d.com/ScriptReference/Canvas.html>.
	
}
*/