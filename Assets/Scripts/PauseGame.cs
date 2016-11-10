using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    public Transform Canvas;

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {

            Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;

        }
    }


}

