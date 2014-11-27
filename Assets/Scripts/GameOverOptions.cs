using UnityEngine;
using System.Collections;

public class GameOverOptions : MonoBehaviour {

	sceneFadeInOut end;
	public bool sceneEnding = false;
	public string level;

	void Awake () {
		end = GameObject.FindWithTag ("sceneFader").GetComponent<sceneFadeInOut> ();
	}

	void Update(){
		if (Input.GetKey (KeyCode.Escape)) {
			sceneEnding = true;
			level = "StartMenu";
		} else if (Input.GetKey (KeyCode.T)) {
			sceneEnding = true;
			level = "Town";
		}
		if (sceneEnding)
			end.EndScene(level);
	}
}
