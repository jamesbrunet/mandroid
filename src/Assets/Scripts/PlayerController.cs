using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public Text countText;
	public Text winText;

	public float speed;

	private Rigidbody rb;
	private int count;

	void Start()
	{
		//This stops the device from falling asleep when only using the accelerometer
		Screen.sleepTimeout = SleepTimeout.NeverSleep; 

		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
		
	void FixedUpdate() 
	{
		//Fetch input from user. This varies based on device type.
		float moveHorizontal = 0;
		float moveVertical = 0;
		if (SystemInfo.deviceType == DeviceType.Desktop) {
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		} else {
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
		}
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);

	}
		
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			winText.text = "You Win!";
		}
	}
}