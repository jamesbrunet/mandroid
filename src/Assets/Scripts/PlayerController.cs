using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Our playercontroller is responsible for:
// -Keeping track of its speed
// -Picking up other game objects
// -Keeping track of the score
// The speed tracking, pickups, and score is from
// the unity roll a ball tutorial


public class PlayerController : MonoBehaviour {

    public float speed;
	public Text countText;
	public Text winText;
    public bool win = false;
    public bool alive = true;
    public GameObject explosionParticles;
    private int score;
    //Fuel
    public float fuel;
    public Slider fuelSlider;
  
    private Rigidbody rb;

	void Start () {
        //This stops the device from falling asleep when only using the accelerometer
        score = PlayerPrefs.GetInt("score",score);
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
        
        this.GetComponent<ParticleSystem>().Play();
        alive = false;
        this.gameObject.SetActive(false);
        
        //winText.text = "You died!";
    }


	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			score += 1;
			SetCountText ();
		}


        if (other.gameObject.CompareTag("LevelBounds")){
            isDestroyed();
        }
	}

	void SetCountText(){
		countText.text = "Count: " + score.ToString ();
		if (score >= 12 && Application.loadedLevel == 1) {
            PlayerPrefs.SetInt("score", score);
            win = true;
        }
        if (score >= 24)
        {
            win = true;
        }
        
	}


    public void spendFuel()
    {
        fuel -= 1;
    }
}
