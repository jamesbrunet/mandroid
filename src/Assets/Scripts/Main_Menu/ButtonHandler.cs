using UnityEngine; using System.Collections;

public class ButtonHandler : MonoBehaviour { 
	public void LoadScene(string sceneName) { 
		Application.LoadLevel(sceneName);
	}
}
