﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


    

public class gameStart : MonoBehaviour {

    public Text winText;
    public GameObject ship;


    // Use this for initialization
    void Start () {
	}
	

    void youWin()
    {
        
        if (ship.GetComponent<PlayerController>().win == true)
        {
            winText.text = "You Win!";
            if (Application.loadedLevel == 1)
            {
                SceneManager.LoadScene(3);
            }
            else
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    void youLose()
    {
        if (ship.GetComponent<PlayerController>().alive == false) { 
            winText.text = "You Lose!";
            SceneManager.LoadScene(2);
        }
    }



	// Update is called once per frame
	void Update () {
        youWin();
        youLose();
	}
}
