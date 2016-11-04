using UnityEngine;
using System.Collections;

public class orbitPlanet : MonoBehaviour {

    public float gravitationalConstant = 10.0f;


	// Use this for initialization
	void Start () {
	
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        var ship = GameObject.Find("pShip");
        var planet = GameObject.Find("Planet");
        Vector3 diff = planet.transform.position - ship.transform.position;
        Vector3 direction = diff.normalized;
        float gravitationalForce = (planet.GetComponent<Rigidbody2D>().mass * ship.GetComponent<Rigidbody2D>().mass * gravitationalConstant) / diff.sqrMagnitude;
        ship.GetComponent<Rigidbody2D>().AddForce(direction * gravitationalForce);
    }
}
