using UnityEngine;
using System.Collections;

public class Gravitational : MonoBehaviour {

    public float gravitationalConstant = 9.6f;
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
                other.GetComponent<PlayerController>().alive = false;
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

    IEnumerator PullPlayer(GameObject player)
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        int counter = 0;

        while (pullCounter == 1)
        {
            counter++;

            // Gravitational Code
            Vector3 offset = this.transform.position - player.transform.position;
            Vector3 direction = offset.normalized;

            float gravitationalForce = (this.GetComponent<Rigidbody>().mass * playerRb.mass * gravitationalConstant) / offset.sqrMagnitude;

            playerRb.AddForce(direction * gravitationalForce);

            yield return new WaitForFixedUpdate();
        }
    }
}
