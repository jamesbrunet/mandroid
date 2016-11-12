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
            this.isPickedUp = true;
        }

        if (other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Fuel"))
            {
                print("Fuel just picked up!");
                this.isPickedUp = true;
                   other.gameObject.GetComponent<PlayerController>().fuel = 2000;
            }
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


