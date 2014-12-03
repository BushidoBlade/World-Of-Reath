using UnityEngine;
using System.Collections;

public class GameOverOptions : MonoBehaviour {

	sceneFadeInOut end;
	public bool sceneEnding = false;
	public string level;

	void Awake () {
		end = GameObject.FindWithTag ("sceneFader").GetComponent<sceneFadeInOut> ();
		Destroy (GameObject.FindWithTag("GameMusic"));
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			sceneEnding = true;
			level = "StartMenu";
		}
		if (Input.GetKey (KeyCode.T)) {
			sceneEnding = true;
			level = "Town";
		}
		if (sceneEnding) {
			if (audio.volume > 0)
				audio.volume -= Time.deltaTime;
			end.EndScene (level);
		}
	}
}
