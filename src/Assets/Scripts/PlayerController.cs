using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    //Fuel
    public float fuel;
    public Slider fuelSlider;
  
    private Rigidbody rb;
	private int score;

	void Start () {
        //This stops the device from falling asleep when only using the accelerometer
        this.gameObject.SetActive(true);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
        fuel = 2000;
        rb = GetComponent<Rigidbody>();
		score = 0;
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
		if (score >= 12) {
            win = true;
		}
	}


    public void spendFuel()
    {
        fuel -= 1;
    }
}
