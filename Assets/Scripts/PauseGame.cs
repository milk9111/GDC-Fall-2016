﻿using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    public Transform Canvas;
    public bool restart;



    void Start()
    {
        Cursor.visible = false;
		Time.timeScale = 1.0f;
		//listener.enabled = true;
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            restart = false;
            Pause();
            //Restart();
        }

    }
    public void Pause()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {
            Cursor.visible = true;
            Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Cursor.visible = false;
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1;

        }
    }

    public void Restart()
    {
		Application.LoadLevel (Application.loadedLevel);
    }




}

