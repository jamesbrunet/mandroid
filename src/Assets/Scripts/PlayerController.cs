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

    private Rigidbody rb;
	private int score;
    public float fuel;
    public Slider fuelSlider;


	void Start () {
		//This stops the device from falling asleep when only using the accelerometer
		Screen.sleepTimeout = SleepTimeout.NeverSleep; 

        rb = GetComponent<Rigidbody>();
        fuel = 2000;
		score = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate () {

        fuelSlider.value = fuel;
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			score += 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + score.ToString ();
		if (score >= 12) {
			winText.text = "You Win!";
		}
	}

   public void spendFuel(){
        fuel = fuel - 1;
    }
}
