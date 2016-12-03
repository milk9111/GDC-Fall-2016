using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	void Start() {

		Button thisButton = this.transform.GetComponent<Button>();
		thisButton.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick() {

		Debug.Log("Start was pressed");

		SceneManager.LoadSceneAsync("Scenes/Done_Main", LoadSceneMode.Single);
	}
}