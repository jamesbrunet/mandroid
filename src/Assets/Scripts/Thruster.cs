using UnityEngine;
using System.Collections;

public class Thruster : MonoBehaviour
{

    public float thrusterMovementSpeed = 1f;
    public float thrusterRotationSpeed = 0.5f;
    public float maxSpeed = 5.0f;

    private GameObject thrusterParent;
    private Rigidbody thrusterParentRb;
    private ParticleSystem thrusterParticles;
    private GameObject ship;

    // Use this for initialization
    void Start()
    {
        thrusterParent = this.transform.parent.gameObject;
        thrusterParentRb = thrusterParent.GetComponent<Rigidbody>();
        ship = GameObject.Find("Player");
        switch(this.tag){
            case "FrontThruster":
                thrusterParticles = (GameObject.FindGameObjectWithTag("FrontThrusterParticles")).GetComponent<ParticleSystem>();
                break;
            case "BackThruster":
                thrusterParticles = (GameObject.FindGameObjectWithTag("BackThrusterParticles")).GetComponent<ParticleSystem>();
                break;
            case "LeftThruster":
                thrusterParticles = (GameObject.FindGameObjectWithTag("LeftThrusterParticles")).GetComponent<ParticleSystem>();
                break;
            case "RightThruster":
                thrusterParticles = (GameObject.FindGameObjectWithTag("RightThrusterParticles")).GetComponent<ParticleSystem>();
                break;
        }
    }

    void FixedUpdate()
        {

        // Definitions of the screen sections in a mobile device
        Rect screenUp = new Rect(0, 0, Screen.width, Screen.height / 4);
        Rect screenDown = new Rect(0, Screen.height - (Screen.height / 4), Screen.width, Screen.height / 4);
        Rect screenLeft = new Rect(0, Screen.height / 4, Screen.width / 2, Screen.height / 2);
        Rect screenRight = new Rect(Screen.width / 2, Screen.height / 4, Screen.width / 2, Screen.height / 2);

        // Flag denoting which screen section was recently touched in a mobile device
        bool touchLeft = false;
        bool touchRight = false;
        bool touchUp = false;
        bool touchDown = false;

        //Store the current horizontal input for axis control.
        float axisHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input for axis control.
        float axisVertical = Input.GetAxis("Vertical");

        // Detect which screen section were recently touched in a mobile device
        for (int i = 0; i < Input.touchCount; i++ )
        {
            if(screenUp.Contains(Input.touches[i].position)){
                touchUp = true;
            }else if(screenDown.Contains(Input.touches[i].position)){
                touchDown = true;
            }else if(screenLeft.Contains(Input.touches[i].position)){
                touchLeft = true;
            }
            else if (screenRight.Contains(Input.touches[i].position))
            {
                touchRight = true;
            }
        }

        // Check if input requires forward movement
        if(this.tag == "FrontThruster"){
            if(axisVertical < 0 || touchDown){
                thrusterParentRb.AddRelativeForce((new Vector3(0, 0, -1)) * thrusterMovementSpeed, ForceMode.Acceleration);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
        }

        // Check if input requires backward movement
        if(this.tag == "BackThruster"){
            if (axisVertical > 0 || touchUp)
            {
                thrusterParentRb.AddRelativeForce((new Vector3(0, 0, 1)) * thrusterMovementSpeed, ForceMode.Acceleration);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
        }

        // Check if input requires rotation to the right
        if(this.tag == "LeftThruster" || touchLeft){
            if (axisHorizontal > 0)
            {
                thrusterParentRb.AddRelativeTorque(thrusterParent.transform.up * thrusterRotationSpeed);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
        }

        // Check if input requires rotation to the left
        if(this.tag == "RightThruster" || touchRight){
            if (axisHorizontal < 0)
            {
                thrusterParentRb.AddRelativeTorque(-thrusterParent.transform.up * thrusterRotationSpeed);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
        }

        // Check if maximum allowed speed has been reached and limit further acceleration
        if (thrusterParentRb.velocity.magnitude > maxSpeed)
            thrusterParentRb.velocity = thrusterParentRb.velocity.normalized * maxSpeed;

    }
}
