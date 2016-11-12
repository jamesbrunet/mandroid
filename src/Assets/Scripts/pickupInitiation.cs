using UnityEngine;
using System.Collections;

public class pickupInitiation : MonoBehaviour {
	// Use this for initialization

    bool isPickedUp = false;

	void Start () {
        this.gameObject.SetActive(true);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Player just hit pickup");
            this.isPickedUp = true;
        }
    }



    //Update is called once per frame
	void Update () {
        if(isPickedUp == true)
        {
            this.gameObject.SetActive(false);
        }
    }
}


