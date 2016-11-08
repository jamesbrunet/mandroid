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

        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");
        
        if(this.tag == "FrontThruster"){
            if(moveVertical < 0){
                thrusterParentRb.AddRelativeForce((new Vector3(0, 0, -1)) * thrusterMovementSpeed, ForceMode.Acceleration);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
        }else if(this.tag == "BackThruster"){
            if (moveVertical > 0)
            {
                thrusterParentRb.AddRelativeForce((new Vector3(0, 0, 1)) * thrusterMovementSpeed, ForceMode.Acceleration);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
        }else if(this.tag == "LeftThruster"){
            if (moveHorizontal > 0)
            {
                thrusterParentRb.AddRelativeTorque(thrusterParent.transform.up * thrusterRotationSpeed);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
        }else if(this.tag == "RightThruster"){
            if (moveHorizontal < 0)
            {
                thrusterParentRb.AddRelativeTorque(-thrusterParent.transform.up * thrusterRotationSpeed);
                thrusterParticles.Play();
                ship.GetComponent<PlayerController>().spendFuel();
            }
            
        }

        if (thrusterParentRb.velocity.magnitude > maxSpeed)
            thrusterParentRb.velocity = thrusterParentRb.velocity.normalized * maxSpeed;

    }
}
