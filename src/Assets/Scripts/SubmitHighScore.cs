using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SubmitHighScore : MonoBehaviour {
	public string highScoreServerURL = "127.0.0.1:8000";
	private string dir = "/high_scores/"; 
	public InputField usernameField;

	public void POSTScore() {
		WWWForm form = new WWWForm ();
		form.AddField ("user_name", usernameField.text);
		form.AddField ("score", PlayerPrefs.GetInt ("score").ToString ());
		WWW www = new WWW(highScoreServerURL + dir, form);

		StartCoroutine (WaitForRequest (www));
	}
	IEnumerator WaitForRequest(WWW www) {
		yield return www;
		if (www.error == null)
		{
			Debug.Log ("Post OK!: " + www.data);
		} else {
			Debug.Log("WWW Error: " + www.error);
		}
		SceneManager.LoadScene(2);
	}

}
