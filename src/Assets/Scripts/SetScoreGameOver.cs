using UnityEngine;
using System.Collections;

public class SetScoreGameOver : MonoBehaviour {

	private TextMesh txt;
	// Use this for initialization
	void Start () {
		txt = gameObject.GetComponent<TextMesh>();
		txt.text = "Your score was " + PlayerPrefs.GetInt ("score").ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
