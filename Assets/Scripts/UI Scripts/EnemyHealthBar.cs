using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour {

	public Image health1, health2;
	public Text healthFraction;
	public Text unitName;
	private GameObject currentUnit = null;
	private long maxHealth;
	private long currentHealth;

	public float timer;

	void Awake() {

		health1.fillAmount = 0.0f;
		health2.fillAmount = 0.0f;
	}

	void FixedUpdate() {


		/*
		timer -= Time.deltaTime;
		if (health1. visibility or something == 1.0f && timer > 0.0f) {*/

		// An if-else block to handle the player objects destruction.
		if (currentUnit != null) {
			
			maxHealth = currentUnit.GetComponent<UnitInfo>().getMaxHealth();
			currentHealth = currentUnit.GetComponent<UnitInfo>().getCurrentHealth();

			health1.fillAmount = (float)currentHealth / (float)maxHealth;
			health2.fillAmount = (float)currentHealth / (float)maxHealth;

			healthFraction.text = (currentHealth +"/"+ maxHealth);
			unitName.text = currentUnit.ToString();

		} else {

			health1.fillAmount = 0.0f;
			health2.fillAmount = 0.0f;

			healthFraction.text = "";
			unitName.text = "";
		}

		/*
		}
		else {
			health1. visibilty or something -= Time.deltaTime;
		}
		*/
	}

	public void setCurrentUnit(GameObject newUnit) {
		currentUnit = newUnit;
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