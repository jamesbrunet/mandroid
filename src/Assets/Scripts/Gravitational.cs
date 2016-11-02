using UnityEngine;
using System.Collections;

public class Gravitational : MonoBehaviour {

    public float gravityStrength = 10.0f;
    private int pullCounter;

	// Use this for initialization
	void Start () {
        pullCounter = 0;
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player")
        {
            pullCounter++;
            //Debug.Log("Counter: " + pullCounter);
            if(pullCounter == 1){
                StartCoroutine(PullPlayer(other.gameObject));
                //Debug.Log("Corrutine Started.");
            }else if(pullCounter == 2){
                other.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            pullCounter--;

            //Debug.Log("Counter: " + pullCounter);
        }
    }

    IEnumerator PullPlayer(GameObject player) { 
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        int counter = 0;

        while(pullCounter == 1){
            counter++;

            // Gravitational Code
            Vector3 offset = this.transform.position - player.transform.position;

            //float magsqr = offset.sqrMagnitude;
            playerRb.AddForce(gravityStrength * offset.normalized, ForceMode.Acceleration);

            yield return new WaitForFixedUpdate();
        }

        //Debug.Log("Corrutine Ended");
    }
}
