using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


    

public class gameStart : MonoBehaviour {

    public Text winText;
    public GameObject ship;


    // Use this for initialization
    void Start () {
	}

	public void Begin()
    {
        SceneManager.LoadScene(1);
    }

    //Checks which scene state the game is in, changes it accordingly.
    void youWin()
    {

        if (ship.GetComponent<PlayerController>().win == true)
        {
            winText.text = "You Win!";
            if (Application.loadedLevel == 1)
            {
                SceneManager.LoadScene(3);
           	}
			else if (Application.loadedLevel == 3)
			{
				SceneManager.LoadScene(5);
			}
            else
            {
                SceneManager.LoadScene(4);
            }
        }
    }

//Game over screen initiates, then the highscore page displays
    void youLose()
    {
        if (ship.GetComponent<PlayerController>().alive == false) { 
            winText.text = "You Lose!";
            SceneManager.LoadScene(4);
        }
    }



	// Update is called once per frame
	void Update () {
        youWin();
        youLose();
	}
}
