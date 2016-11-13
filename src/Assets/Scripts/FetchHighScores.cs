using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class FetchHighScores : MonoBehaviour {

	public string highScoreServerURL = "127.0.0.1:8000";
	private string fetchJSON = "/high_scores/?json";

	private TextMesh txt;


	// Use this for initialization
	void Start () {
		StartCoroutine (fetchWWW());
	}

	private IEnumerator fetchWWW () {
		WWW www = new WWW(highScoreServerURL + fetchJSON);
		yield return www;

		JSONObject highScores = new JSONObject(www.text);

		// JSONObject does not support lists. I have to do implemenet this manually.
		// Warning: This is kind of hacky
		string[] highScoresList = highScores.GetField ("high_scores")
			.ToString ()
			.Replace ("[", "")
			.Replace ("]", "")
			.Replace("},", "},,,,,") // Don't ask.
			.Split (new string[] {",,,,,"}, System.StringSplitOptions.None);

		txt = gameObject.GetComponent<TextMesh>();
		txt.text = "";

		int i = 1; //keep track of position of player
		foreach (string highScore in highScoresList) {
			JSONObject currentScore = new JSONObject (highScore); 
			//txt.text += highScore;
			if (i > 9) {
				txt.text += i.ToString () + ". "
				+ string.Format ("{0, -11} | {1, 4}",
					currentScore.GetField ("username").ToString ().Replace ("\"", ""),
					currentScore.GetField ("score").ToString ())
				+ "\n";
				i++;
			} else {

				txt.text += i.ToString () + ". "
				+ string.Format ("{0, -12} | {1, 4}",
					currentScore.GetField ("username").ToString ().Replace ("\"", ""),
					currentScore.GetField ("score").ToString ())
				+ "\n";
				i++;
			}
		}
	}

	// Update is called once per frame
	void Update () {
	}
}

