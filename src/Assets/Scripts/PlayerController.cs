using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Our playercontroller is responsible for:
// -Keeping track of its speed
// -Picking up other game objects
// -Keeping track of the score
// The speed tracking, pickups, and score is from
// -Checking win/loss states.


public class PlayerController : MonoBehaviour {

    public float speed;
	public Text countText;
	public Text winText;
    public bool win = false;
    public bool alive = true;
    public GameObject explosionParticles;
    public int score;
    //Fuel
    public float fuel;
    public Slider fuelSlider;
  
    private Rigidbody rb;

    //Getters
    public float getSpeed()
    {
        return speed;
    }

    public bool getWin()
    {
        return win;
    }

    public bool getAlive()
    {
        return alive;
    }

    public int getScore()
    {
        return score;
    }

    public float getFuel()
    {
        return fuel;
    }
    //Setters
    public void setSpeed(float newSpeed)
    {
        newSpeed = speed;
    }

    public void setWin(bool newWin)
    {
        newWin = win;
    }

    public void setAlive(bool newAlive)
    {
        newAlive = alive;
    }

    public void setScore(int newScore)
    {
        newScore = score;
    }

    public void setFuel(float newFuel)
    {
        newFuel = fuel;
    }

	void Start () {
        
		if (Application.loadedLevel == 1) {
			PlayerPrefs.SetInt ("score", 0); 
		}

		if (Application.loadedLevel == 3)
        {
            win = false;
            print("Score loading!");
            score = PlayerPrefs.GetInt("score");
        }
		else if (Application.loadedLevel == 5)
		{
			win = false;
			print("Score loading!");
			score = PlayerPrefs.GetInt("score");
		}
        else
        {
            score = 0;
        }
        this.gameObject.SetActive(true);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
        fuel = 2000;
        rb = GetComponent<Rigidbody>();
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate () {
        fuelSlider.value = fuel;
	}

    public void isDestroyed()
    {
        
        //this.GetComponent<ParticleSystem>().Play();
        alive = false;
        this.gameObject.SetActive(false);
        
        //winText.text = "You died!";
    }


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			score += 1;
			SetCountText ();
            PlayerPrefs.SetInt("score", score);
        }


        if (other.gameObject.CompareTag("LevelBounds")){
            isDestroyed();
        }

        if (other.gameObject.CompareTag("Exit"))
        {
            win = true;
        }
        if (other.gameObject.CompareTag("Asteroid"))
        {
            isDestroyed();
        }
	}

	void SetCountText(){
		countText.text = "Count: " + score.ToString ();
        //Win first level with max score
		if (score >= 12 && Application.loadedLevel == 1) {
            win = true;
        }
        //Win second level with max score
        if (score >= 24 && Application.loadedLevel == 3)
        {
            win = true;
        }
		if (score >= 36 && Application.loadedLevel == 5)
		{
			win = true;
		}

        
	}


    public void spendFuel()
    {
        fuel -= 1;
    }
}
