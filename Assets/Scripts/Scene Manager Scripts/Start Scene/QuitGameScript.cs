using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitGameScript : MonoBehaviour {

	void Start() {

		Button thisButton = this.transform.GetComponent<Button>();
		thisButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick() {

		Debug.Log("Quit was pressed");

		//Application.Quit();
	}
}